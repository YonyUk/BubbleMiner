using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Generators{

	public class Generator{
		float probability { get; set; }
		float coral_probability { get; set; }
		int types { get; set; }
		int[,] map { get; set; }
		int initials { get; set; }
		int rows { get; set; }
		int cols { get; set; }
		List<Vector2> discovered_cells { get; set; }
		List<Vector2> cells { get; set; }
		System.Random random { get; set; }
		int max_iterations { get; set; }
		int iterations { get; set; }

		public Generator(int rows,int cols, int types, int iterations, float probability){
			this.types = types;
			this.rows = rows;
			this.cols = cols;
			initials = (int)(rows * cols * 0.1);
			map = new int[rows, cols];
			discovered_cells = new List<Vector2> ();
			cells = new List<Vector2> ();
			random = new System.Random ();
			max_iterations = iterations;
			this.iterations = 0;
			this.probability = probability;
			coral_probability = 0.33f;
			init_cells ();
		}
		void init_cells(){
			for (int i = 0; i < initials; i++) {
				discovered_cells.Add(new Vector2(random.Next(0,rows),random.Next (0,cols)));
			}
		}
		bool is_in_range(Vector2 pos){
			return pos.x > -1 && pos.x < rows && pos.y > -1 && pos.y < cols;
		}
		Vector2[] neigborhs(Vector2 pos){
			int[] dir_x = new[]{-1,0,1,0};
			int[] dir_y = new[]{0,1,0,-1};
			List<Vector2> result = new List<Vector2> ();
			for (int i = 0; i < 4; i++) {
				Vector2 n = pos + new Vector2(dir_x[i],dir_y[i]);
				if (is_in_range(n))
					result.Add(n);
			}
			return result.ToArray ();
		}
		public int[,] Map {
			get{
				return map;
			}
		}
		public IEnumerable<Vector2> Cells{
			get{
				foreach( var cell in cells)
					yield return cell;
				yield break;
			}
		}
		public int InitialCells {
			get{
				return initials;
			}
			set{
				if (!(value >= map.GetLength(0) * map.GetLength(1) * 0.5))
					initials = value;
			}
		}
		public void Generate(){
			while (next());
		}
		bool next(){
			if (iterations == max_iterations)
				return false;
			List<Vector2> new_cells = new List<Vector2> ();
			for (int i = 0; i < discovered_cells.Count; i++){
				Vector2[] neigborhs_ = neigborhs(discovered_cells[i]);
				foreach(var n in neigborhs_){
					cells.Add(n);
					float r = (float)random.NextDouble();
					if (r < probability){
						r = (float)random.NextDouble();
						if (r < coral_probability)
							map[(int)n.x,(int)n.y] = 1;
						else{
							int value = random.Next(2,types + 1);
							map[(int)n.x,(int)n.y] = value;
						}
						new_cells.Add(n);
					}
				}
			}
			discovered_cells = new_cells;
			iterations ++;
			return true;
		}
		public void Restart(){
			iterations = 0;
		}
		public bool ClearInRange(Vector2 pos, int radious){
			if (pos.x - radious < 0 || pos.x + radious > rows - 1 || pos.y - radious < 0 || pos.y + radious > cols - 1)
				return false;
			for (int i = (int)pos.x - radious; i < pos.x + radious; i++)
				for (int j = (int)pos.y - radious; j < pos.y + radious; j++)
					map [i, j] = 0;
			return true;
		}
	}
}