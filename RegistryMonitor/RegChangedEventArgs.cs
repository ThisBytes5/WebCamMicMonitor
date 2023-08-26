using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryUtils
{
  public class RegChangedEventArgs : EventArgs
  {
    public string ID { get; set; }
    public string RegistryKey { get; internal set; }
  }
}
