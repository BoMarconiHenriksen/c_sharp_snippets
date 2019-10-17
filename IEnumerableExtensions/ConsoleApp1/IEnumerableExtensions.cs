using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
  public static class IEnumerableExtensions
  {
    public static IEnumerable<IEnumerable<T>> ComputePaths<T>(T Root, Func<T, IEnumerable<T>> Children)
    {
      var children = Children(Root); 
      if (children != null && children.Any())
      {
        foreach (var Child in children)
          foreach (var ChildPath in ComputePaths(Child, Children))
            yield return new[] { Root }.Concat(ChildPath);
      }
      else
      {
        yield return new[] { Root };
      }
    }

    public static IEnumerable<IEnumerable<T>> ComputePathsForAllItems<T>(this IEnumerable<T> assetList, Func<T, IEnumerable<T>> funcChildren)
    {
      return assetList.SelectMany(a => IEnumerableExtensions.ComputePaths(a, funcChildren));
    }
  }
}
