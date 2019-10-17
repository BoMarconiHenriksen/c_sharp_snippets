using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
  class Program
  {
    static void Main(string[] args)
    {
      AssetListViewAsset assetListViewAsset = new AssetListViewAsset();

      // Test Data
      var asset1 = new AssetListViewAsset()
      {
        AssetID = 1,
        FromRelations = new List<AssetListViewAsset>
        {
          new AssetListViewAsset
          {
            AssetID = 11,
            FromRelations = new List<AssetListViewAsset>
            {
              new AssetListViewAsset
              {
                AssetID = 21,
                FromRelations = new List<AssetListViewAsset>
                {
                  new AssetListViewAsset
                  {
                    AssetID = 31,
                    StringValues = new List<AssetListViewAsset.StringValue>
                    {
                      new AssetListViewAsset.StringValue { AssetFieldDefinitionID = 1, Value = "Kurt" },
                      new AssetListViewAsset.StringValue { AssetFieldDefinitionID = 2, Value = "Curbain" }
                    }
                  }
                },
                StringValues = new List<AssetListViewAsset.StringValue>
                {
                  new AssetListViewAsset.StringValue { AssetFieldDefinitionID = 1, Value = "Jan" },
                  new AssetListViewAsset.StringValue { AssetFieldDefinitionID = 2, Value = "Sonnegaard" }
                },             
              }
            },
            StringValues = new List<AssetListViewAsset.StringValue>
            {
              new AssetListViewAsset.StringValue { AssetFieldDefinitionID = 1, Value = "Frans" },
              new AssetListViewAsset.StringValue { AssetFieldDefinitionID = 2, Value = "Kafka" }
            },
          },
          new AssetListViewAsset
          {
            AssetID = 12,
            FromRelations = new List<AssetListViewAsset>
            {
              new AssetListViewAsset
              {
                AssetID = 22,
                StringValues = new List<AssetListViewAsset.StringValue>
                {
                  new AssetListViewAsset.StringValue { AssetFieldDefinitionID = 1, Value = "Jan" },
                  new AssetListViewAsset.StringValue { AssetFieldDefinitionID = 2, Value = "Sonnegaard" }
                },
              }
            },
            StringValues = new List<AssetListViewAsset.StringValue>
            {
              new AssetListViewAsset.StringValue { AssetFieldDefinitionID = 1, Value = "Frans" },
              new AssetListViewAsset.StringValue { AssetFieldDefinitionID = 2, Value = "Kafka" }
            },
          }
        },
        StringValues = new List<AssetListViewAsset.StringValue>
        {
          new AssetListViewAsset.StringValue { AssetFieldDefinitionID = 1, Value = "Hans" }, 
          new AssetListViewAsset.StringValue { AssetFieldDefinitionID = 2, Value = "Jensen" } 
        },
      };
     
      var asset2 = new AssetListViewAsset()
      {
        AssetID = 9,
        FromRelations = new List<AssetListViewAsset>
        {
          new AssetListViewAsset
          {
            AssetID = 19,
            FromRelations = new List<AssetListViewAsset>
            {
              new AssetListViewAsset
              {
                AssetID = 29,
                FromRelations = new List<AssetListViewAsset>
                {
                  new AssetListViewAsset
                  {
                    AssetID = 39,
                    StringValues = new List<AssetListViewAsset.StringValue>
                    {
                      new AssetListViewAsset.StringValue { AssetFieldDefinitionID = 1, Value = "Kurt2" },
                      new AssetListViewAsset.StringValue { AssetFieldDefinitionID = 2, Value = "Curbain2" }
                    }
                  }
                },
                StringValues = new List<AssetListViewAsset.StringValue>
                {
                  new AssetListViewAsset.StringValue { AssetFieldDefinitionID = 1, Value = "Jan2" },
                  new AssetListViewAsset.StringValue { AssetFieldDefinitionID = 2, Value = "Sonnegaard2" }
                },
              }
            },
            StringValues = new List<AssetListViewAsset.StringValue>
            {
              new AssetListViewAsset.StringValue { AssetFieldDefinitionID = 1, Value = "Frans2" },
              new AssetListViewAsset.StringValue { AssetFieldDefinitionID = 2, Value = "Kafka2" }
            },
          }
        },
        StringValues = new List<AssetListViewAsset.StringValue>
        {
          new AssetListViewAsset.StringValue { AssetFieldDefinitionID = 1, Value = "Hans2" }, // First name
          new AssetListViewAsset.StringValue { AssetFieldDefinitionID = 2, Value = "Jensen2" } // Last name
        },
      };

      // Test testdata
      //Console.WriteLine("Asset Id: " + asset1.AssetID);
      //Console.WriteLine("Asset Id: " + asset2.AssetID);

      var assetList = new List<AssetListViewAsset>();
      assetList.Add(asset1);
      assetList.Add(asset2);

      var nodeRoot = assetList.FirstOrDefault();

      // Without the extension method.
      var paths = assetList.SelectMany(a => IEnumerableExtensions.ComputePaths(a, n => n.FromRelations));
      
      // With the extension method.
      var pathsForEachAsset = assetList.ComputePathsForAllItems(n => n.FromRelations);

      // Get each id.
      foreach (var a in pathsForEachAsset)
        Console.WriteLine(a.Select(v => v.AssetID).FirstOrDefault());

      var strPaths = from p in paths select string.Join(":", p.Select(t => t.AssetID).ToArray());

      foreach (var p in strPaths)
        Console.WriteLine(p);
    }   
  }
}
