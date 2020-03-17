using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chargoon.Sample.Framework
{
	public interface IDependencyRegistrar
	{
		void Register(Container container);

	}
}
