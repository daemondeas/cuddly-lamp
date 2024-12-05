using Microsoft.FSharp.Collections;

namespace cuddly_lamp.utils;

public static class Utilities
{
  public static FSharpList<int> SortUpdate(IReadOnlyDictionary<int, FSharpList<int>> rules, FSharpList<int> update)
  {
    var updateArray = update.ToArray();
    var i = 0;
    while (i < updateArray.Length)
    {
      if (!rules.ContainsKey(updateArray[i]))
      {
        i++;
        continue;
      }

      var moved = false;
      for (var j = updateArray.Length - 1; j > i && !moved; j--)
      {
        if (rules[updateArray[i]].Contains(updateArray[j]))
        {
          var toMove = updateArray[i];
          for (var k = i; k < j; k++)
          {
            updateArray[k] = updateArray[k + 1];
          }

          updateArray[j] = toMove;
          moved = true;
        }
      }

      if (!moved)
      {
        i++;
      }
    }

    return ListModule.OfSeq(updateArray);
  }
}
