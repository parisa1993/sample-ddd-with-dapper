using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Chargoon.Sample.Framework
{
	public static class SampleEnvironment
	{
		public static Container Container { get; private set; }

		private static string GetBinDirectory()
		{
			if (System.Web.Hosting.HostingEnvironment.IsHosted)
			{
				//hosted
				return System.Web.HttpRuntime.BinDirectory;
			}
			else
			{
				//not hosted. For example, run either in unit tests
				return AppDomain.CurrentDomain.BaseDirectory;
			}
		}
		public static void Start()
		{
			Container = new Container();
			foreach (var instance in Load(GetBinDirectory()))
			{
				instance.Register(Container);
			}
		}

		private static List<IDependencyRegistrar> Load(string folderPath)
		{
			var interfaceInstances = new List<IDependencyRegistrar>();
			var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();

			foreach (string dllPath in Directory.GetFiles(folderPath, "*.dll"))
			{
				try
				{
					var dllNameWithoutExtension = Path.GetFileNameWithoutExtension(dllPath);


					var asm = loadedAssemblies.FirstOrDefault(a => a.FullName.Split(',')[0].Equals(dllNameWithoutExtension, StringComparison.InvariantCultureIgnoreCase));
					if (asm == null)
					{
						asm = Assembly.LoadFrom(dllPath);
						loadedAssemblies.Add(asm);
					}

					var types = asm.GetTypes();

					foreach (var type in types)
					{
						if (type != null && type.GetInterface(nameof(IDependencyRegistrar)) != null)
						{
							interfaceInstances.Add((IDependencyRegistrar)CreateInstance(type));
						}
					}
				}
				catch (ReflectionTypeLoadException ex)
				{ }
				catch (TypeLoadException ex)
				{ }
				catch (BadImageFormatException ex)
				{ }
				catch (FileLoadException ex)
				{ }
				catch (Exception ex)
				{
					throw ex;
				}
			}

			return interfaceInstances;
		}

		private delegate object objectActivator();
		private static object CreateInstance(Type type)
		{
			var newExp = Expression.New(type);
			var lambda = Expression.Lambda(typeof(objectActivator), newExp, null);

			var constructorCallingLambda = ((objectActivator)lambda.Compile());

			return constructorCallingLambda();
		}
	}
}
