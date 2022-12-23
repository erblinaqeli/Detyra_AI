from BFS_Sudoku import BFS_solve
from DFS_Sudoku import DFS_solve
from Heuristics_Sudoku import H_Solve
print ("\n\nTesting on medium 9x9 grid...")
grid = [[0,0,2,0,3,0,0,0,8],
      [0,0,0,0,0,8,0,0,0],
      [0,3,1,0,2,0,0,0,0],
      [0,6,0,0,5,0,2,7,0],
      [0,1,0,0,0,0,0,5,0],
      [2,0,4,0,6,0,0,3,1],
      [0,0,0,0,8,0,6,0,5],
      [0,0,0,0,0,0,0,1,3],
      [0,0,5,3,1,0,4,0,0]]

print ("Problem:")
for row in grid:
      print (row)

BFS_solve(grid)
DFS_solve(grid)
H_Solve(grid)

print ("\n\nTesting unsolvable quadrant on a 9x9 grid...")
grid =[
        [3, 0, 5, 4, 0, 2, 0, 6, 0],
        [4, 9, 0, 7, 6, 0, 1, 0, 8],
        [6, 0, 0, 1, 0, 3, 2, 4, 5],
        [0, 0, 3, 9, 0, 0, 5, 8, 0],
        [9, 6, 0, 0, 0, 0, 7, 0, 3],
        [0, 8, 1, 3, 0, 4, 0, 9, 2],
        [0, 5, 0, 6, 0, 1, 4, 0, 0],
        [2, 0, 0, 5, 4, 9, 0, 7, 0],
        [1, 4, 9, 0, 0, 7, 3, 0, 6]
        ]

print ("Problem:")
for row in grid:
      print (row)

BFS_solve(grid)
DFS_solve(grid)
H_Solve(grid)


H_Solve(grid)
