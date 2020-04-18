using Microsoft.Xna.Framework;

namespace Terraria.World.Generation
{
	public static class Biomes<T> where T : MicroBiome, new()
	{
		private static T _microBiome = CreateInstance();

		public static bool Place(int x, int y, StructureMap structures)
		{
			return _microBiome.Place(new Point(x, y), structures);
		}

		public static bool Place(Point origin, StructureMap structures)
		{
			return _microBiome.Place(origin, structures);
		}

		public static T Get()
		{
			return _microBiome;
		}

		private static T CreateInstance()
		{
			T val = new T();
			BiomeCollection.Biomes.Add(val);
			return val;
		}
	}
}