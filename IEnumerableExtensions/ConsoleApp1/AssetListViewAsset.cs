using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
  public class AssetListViewAsset
  {
    public int AssetID { get; set; }

    public int AssetTypeDefinitionID { get; set; }

    public bool Deleted { get; set; }

    public IEnumerable<StringValue> StringValues { get; set; }

    public IEnumerable<NumberValue> NumberValues { get; set; }

    public IEnumerable<DateTimeValue> DateTimeValues { get; set; }

    public IEnumerable<BlobValue> BlobImageValues { get; set; }

    public IEnumerable<AssetListViewAsset> FromRelations { get; set; }

    public class StringValue
    {
      public int AssetFieldDefinitionID { get; set; }

      public string Value { get; set; }
    }

    public class NumberValue
    {
      public int AssetFieldDefinitionID { get; set; }

      public decimal? Value { get; set; }
    }

    public class DateTimeValue
    {
      public int AssetFieldDefinitionID { get; set; }

      public DateTime? Value { get; set; }
    }

    public class BlobValue
    {
      public int AssetFieldDefinitionID { get; set; }

      public byte[] Value { get; set; }
    }
  }
}
