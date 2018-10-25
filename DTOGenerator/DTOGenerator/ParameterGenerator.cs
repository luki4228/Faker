using DTOGenerator.Generators;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DTOGenerator
{
    internal static class ParameterGenerator
    {
        private static Dictionary<Type, IGenerator> generatorMethods;
        private static Dictionary<string, ICollectionGenerator> collectionGenerator;
        private static List<Type> recursionControl;
        public static Faker Faker { get; set; }
        public static string DirPath { get; set; }

        static ParameterGenerator()
        {
            List<Assembly> allAssemblies = new List<Assembly>();
            foreach (string dll in Directory.GetFiles(DirPath, "*.dll"))
            {
                allAssemblies.Add(Assembly.LoadFile(dll));
            }

            collectionGenerator = new Dictionary<string, ICollectionGenerator>();
            generatorMethods = new Dictionary<Type, IGenerator>();
            generatorMethods.Add(typeof(double), new DoubleGenerator());
            generatorMethods.Add(typeof(uint), new UIntGenerator());
            generatorMethods.Add(typeof(float), new FloatGenerator());
            generatorMethods.Add(typeof(char), new CharGenerator());
            generatorMethods.Add(typeof(string), new StringGenerator());
            generatorMethods.Add(typeof(long), new LongGenerator());
            generatorMethods.Add(typeof(DateTime), new DateGenerator());
            collectionGenerator.Add(typeof(List<>).Name, new ListGenerator());
            recursionControl = new List<Type>();

            foreach (var asm in allAssemblies)
            {
                Console.WriteLine(asm.FullName);
                var types = asm.GetTypes().Where(t => t.GetInterfaces().Where(i => i.Equals(typeof(IGenerator))).Any());
                foreach (var type in types)
                {
                    var plugin = asm.CreateInstance(type.FullName) as IGenerator;
                    Type t = plugin.GetGeneratorType();
                    if (!generatorMethods.ContainsKey(t))
                        generatorMethods.Add(plugin.GetGeneratorType(), plugin);
                }
            }

            collectionGenerator.Add(typeof(List<>).Name, new ListGenerator());
            recursionControl = new List<Type>();
        }

        public static void AddToRecursionControlList(Type t)
        {
            recursionControl.Add(t);
        }

        public static void RemoveFromRecursionControlList(Type t)
        {
            recursionControl.Remove(t);
        }


        public static void ClearRecursionControlList()
        {
            recursionControl.Clear();
        }

        internal static object Generate(Type parameterType)
        {
            if (generatorMethods.ContainsKey(parameterType))
            {
                return generatorMethods[parameterType].Generate();
            }
            if (collectionGenerator.ContainsKey(parameterType.Name))
            {
                return collectionGenerator[parameterType.Name].Generate(parameterType.GenericTypeArguments[0]);
            }
            if (recursionControl.Contains(parameterType))
            {
                throw new InvalidOperationException("Cyclic objects! First DTO contains second DTO as field, second DTO contains first as field.");
            }
            if (DTOChecker.IsDto(parameterType))
            {
                object tmp = Faker.Create(parameterType);
                RemoveFromRecursionControlList(parameterType);
                return tmp;
            }
            return parameterType.IsValueType ? Activator.CreateInstance(parameterType) : null;
        }
    }
}
