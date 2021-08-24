using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using p0.StoreApplication.Domain.Models;

namespace p0.StoreApplication.Storage.Adapters
{
  public class FileAdapter
  {
    public T ReadFromFile<T>(string path) where T : class
    {
      if (!File.Exists(path))
      {
        return null;
      }
      // open file
      var file = new StreamReader(path);
      // serialize object
      var xml = new XmlSerializer(typeof(T));
      // read from file
      var result = xml.Deserialize(file) as T;
      // return data
      return result;
    }

    public void WriteToFile<T>(string path, T data) where T : class
    {
      // open file
      var file = new StreamWriter(path);
      // serialize object
      var xml = new XmlSerializer(typeof(List<T>));
      // write to file
      xml.Serialize(file, data);
    }

    public void UseReadFile()
    {
      // file path
      ReadFromFile<Store>(@"/home/jeffrey/revature/training_repo/data/stores.xml");
    }
  }
}