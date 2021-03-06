using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria.GameContent.Generation;
using Terraria.World.Generation;

namespace Terraria.GameContent.Biomes
{
	internal class MahoganyTreeBiome : MicroBiome
	{
		public override bool Place(Point origin, StructureMap structures)
		{
			Point result;
			if (!WorldUtils.Find(new Point(origin.X - 3, origin.Y), Searches.Chain(new Searches.Down(200), new Conditions.IsSolid().AreaAnd(6, 1)), out result))
			{
				return false;
			}
			Point result2;
			if (!WorldUtils.Find(new Point(result.X, result.Y - 5), Searches.Chain(new Searches.Up(120), new Conditions.IsSolid().AreaOr(6, 1)), out result2) || result.Y - 5 - result2.Y > 60)
			{
				return false;
			}
			if (result.Y - result2.Y < 30)
			{
				return false;
			}
			if (!structures.CanPlace(new Rectangle(result.X - 30, result.Y - 60, 60, 90)))
			{
				return false;
			}
			Dictionary<ushort, int> dictionary = new Dictionary<ushort, int>();
			WorldUtils.Gen(new Point(result.X - 25, result.Y - 25), new Shapes.Rectangle(50, 50), new Actions.TileScanner(0, 59, 147, 1).Output(dictionary));
			int num = dictionary[0] + dictionary[1];
			int num2 = dictionary[59];
			int num3 = dictionary[147];
			if (num3 > num2 || num > num2 || num2 < 50)
			{
				return false;
			}
			int num4 = (result.Y - result2.Y - 9) / 5;
			int num5 = num4 * 5;
			int num6 = 0;
			double num7 = GenBase._random.NextDouble() + 1.0;
			double num8 = GenBase._random.NextDouble() + 2.0;
			if (GenBase._random.Next(2) == 0)
			{
				num8 = 0.0 - num8;
			}
			for (int i = 0; i < num4; i++)
			{
				double num9 = (double)(i + 1) / 12.0;
				int num10 = (int)(Math.Sin(num9 * num7 * 3.1415927410125732) * num8);
				int num11 = (num10 < num6) ? (num10 - num6) : 0;
				WorldUtils.Gen(new Point(result.X + num6 + num11, result.Y - (i + 1) * 5), new Shapes.Rectangle(6 + Math.Abs(num10 - num6), 7), Actions.Chain(new Actions.RemoveWall(), new Actions.SetTile(383), new Actions.SetFrames()));
				WorldUtils.Gen(new Point(result.X + num6 + num11 + 2, result.Y - (i + 1) * 5), new Shapes.Rectangle(2 + Math.Abs(num10 - num6), 5), Actions.Chain(new Actions.ClearTile(true), new Actions.PlaceWall(78)));
				WorldUtils.Gen(new Point(result.X + num6 + 2, result.Y - i * 5), new Shapes.Rectangle(2, 2), Actions.Chain(new Actions.ClearTile(true), new Actions.PlaceWall(78)));
				num6 = num10;
			}
			int num12 = 6;
			if (num8 < 0.0)
			{
				num12 = 0;
			}
			List<Point> list = new List<Point>();
			for (int j = 0; j < 2; j++)
			{
				double num13 = ((double)j + 1.0) / 3.0;
				int num14 = num12 + (int)(Math.Sin((double)num4 * num13 / 12.0 * num7 * 3.1415927410125732) * num8);
				double num15 = GenBase._random.NextDouble() * 0.78539818525314331 - 0.78539818525314331 - 0.20000000298023224;
				if (num12 == 0)
				{
					num15 -= 1.5707963705062866;
				}
				WorldUtils.Gen(new Point(result.X + num14, result.Y - (int)((double)(num4 * 5) * num13)), new ShapeBranch(num15, GenBase._random.Next(12, 16)).OutputEndpoints(list), Actions.Chain(new Actions.SetTile(383), new Actions.SetFrames(true)));
				num12 = 6 - num12;
			}
			int num16 = (int)(Math.Sin((double)num4 / 12.0 * num7 * 3.1415927410125732) * num8);
			WorldUtils.Gen(new Point(result.X + 6 + num16, result.Y - num5), new ShapeBranch(-0.68539818525314333, GenBase._random.Next(16, 22)).OutputEndpoints(list), Actions.Chain(new Actions.SetTile(383), new Actions.SetFrames(true)));
			WorldUtils.Gen(new Point(result.X + num16, result.Y - num5), new ShapeBranch(-2.45619455575943, GenBase._random.Next(16, 22)).OutputEndpoints(list), Actions.Chain(new Actions.SetTile(383), new Actions.SetFrames(true)));
			foreach (Point item in list)
			{
				WorldUtils.Gen(item, new Shapes.Circle(4), Actions.Chain(new Modifiers.Blotches(4, 2), new Modifiers.SkipTiles(383), new Modifiers.SkipWalls(78), new Actions.SetTile(384), new Actions.SetFrames(true)));
			}
			for (int k = 0; k < 4; k++)
			{
				float angle = (float)k / 3f * 2f + 0.57075f;
				WorldUtils.Gen(result, new ShapeRoot(angle, GenBase._random.Next(40, 60)), new Actions.SetTile(383, true));
			}
			WorldGen.AddBuriedChest(result.X + 3, result.Y - 1, (GenBase._random.Next(4) != 0) ? WorldGen.GetNextJungleChestItem() : 0, false, 10);
			structures.AddStructure(new Rectangle(result.X - 30, result.Y - 30, 60, 60));
			return true;
		}
	}
}
