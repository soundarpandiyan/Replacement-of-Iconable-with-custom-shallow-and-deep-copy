using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog("jimmy", 21, "round collar");
            // Deep Copy
            Dog copy = dog.GetCopy(dog, CopyType.DeepCopy);
            copy.CollarType.CollarName = "circle collar";
            copy.DiplayDogDetails();
            dog.DiplayDogDetails();

            // Shallow Copy
            Dog shallowCopy = dog.GetCopy(dog, CopyType.ShallowCopy);
            shallowCopy.CollarType.CollarName = "circle collar";
            shallowCopy.DiplayDogDetails();
            shallowCopy.DiplayDogDetails();
        }
    }

    public enum CopyType
    {
        DeepCopy,
        ShallowCopy
    }

    [Serializable]
    class DogCollar
    {
        public string CollarName;
        public DogCollar(string collarName)
        {
            this.CollarName = collarName;
        }
        public string GetCollar()
        {
            return CollarName;
        }
    }

    [Serializable]
    class Dog
    {
        public string Name;
        public int Age;
        public DogCollar CollarType;

        public Dog(string name, int age, string collarName)
        {
            this.Name = name;
            this.Age = age;
            this.CollarType = new DogCollar(collarName);
        }

        public Dog(Dog other)
        {
            DeepCopy(other);
        }

        public void DiplayDogDetails()
        {
            Console.WriteLine(string.Format("Name : {0}, Age : {1}, Collar Type : {2}", this.Name, this.Age, this.CollarType.GetCollar()));
        }

        public Dog GetCopy(Dog other, CopyType isDeepCopy)
        {
            Dog clone = isDeepCopy == CopyType.DeepCopy ? DeepCopy(other) : ShallowCopy(other);
            Console.WriteLine(isDeepCopy + " copy sucessful");
            return clone;
        }

        public static Dog ShallowCopy(Dog obj)
        {
            return (Dog)obj.MemberwiseClone();
        }

        public static Dog DeepCopy(Dog obj)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, obj);
                stream.Position = 0;

                return (Dog)formatter.Deserialize(stream);
            }
        }
    }
}
