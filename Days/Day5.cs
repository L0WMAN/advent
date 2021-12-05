public class Day5{
    int gridMax;
    int gridMin;
    int[,]? grid; //need to find min/max from file
    public List<Line> lines= new List<Line>();

    public void Calc(){
        string path = "Days/inputDay5.txt";
        using (StreamReader sr = File.OpenText(path)){
            string? tempString;
            while ((tempString = sr.ReadLine()) != null){
            //Console.WriteLine(tempString);
            string[]? splits = tempString.Split(new string[] {" -> ", ","}, StringSplitOptions.None);
            //Console.WriteLine(splits[0]);
            Line tempLine = new Line();
            int[]? coords = Array.ConvertAll(splits, s => int.Parse(s));
            tempLine.startX = coords[0];
            tempLine.startY = coords[1];
            tempLine.endX = coords[2];
            tempLine.endY = coords[3];
            
            int tempMin = Math.Min(tempLine.startX, Math.Min(tempLine.startY, Math.Min(tempLine.endX, tempLine.endY)));
            int tempMax = Math.Max(tempLine.startX, Math.Max(tempLine.startY, Math.Max(tempLine.endX, tempLine.endY)));
            if (tempMin < gridMin){
                gridMin = tempMin;
            }
            if (tempMax > gridMax){
                gridMax = tempMax;
            }

            lines.Add(tempLine);

            }
        }
        //Console.WriteLine(lines.Count);
        //Console.WriteLine("Min: "+ gridMin + " Max: "+ gridMax);
        grid = new int[gridMax+1, gridMax+1];

        foreach (Line l in lines){
            //int xDiff = l.endX - l.startX;
            //int yDiff = l.endY - l.startY;
            if((Math.Abs(l.startX-l.endX) == Math.Abs(l.startY-l.endY))){
                if(l.endX > l.startX){
                    if(l.endY > l.startY){
                        for (int i = 0; l.startX+i <= l.endX; i++){
                            grid[l.startX+i, l.startY+i]++;
                        }
                    }
                    else if (l.startY > l.endY){
                        for (int i = 0; l.startX+i <= l.endX; i++){
                        grid[l.startX+i, l.startY-i]++;
                        }
                    }
                }
                else if(l.startX > l.endX){
                    if(l.endY > l.startY){
                        for (int i = 0; l.endX+i <= l.startX; i++){
                            grid[l.startX-i, l.startY+i]++;
                        }
                    }
                    else if(l.startY > l.endY){
                        for (int i = 0; l.endX+i <= l.startX; i++){
                            grid[l.startX-i, l.startY-i]++;
                        }
                    }
                }
            }
            else if (l.startX == l.endX){
                if(l.endY > l.startY){
                    for (int i = 0; l.startY+i <= l.endY; i++){
                        grid[l.startX, l.startY+i]++;
                    }
                }
                else if (l.endY < l.startY){
                    for (int i = 0; l.endY+i <= l.startY; i++){
                        grid[l.startX, l.endY+i]++;
                    }
                }           
            }
            else if(l.startY == l.endY){
                if(l.endX > l.startX){
                    for (int i = 0; l.startX+i <= l.endX; i++){
                        grid[l.startX+i, l.startY]++;
                    }
                }
                else if (l.endX < l.startX){
                    for (int i = 0; l.endX+i <= l.startX; i++){
                        grid[l.endX+i, l.startY]++;
                    }
                }
            }
        }
        int count = 0;
        for (int i = 0; i < gridMax+1; i++){
            for (int j = 0; j < gridMax+1; j++){
                //Console.Write(grid[j,i]+" ");
                if (grid[i,j] >= 2){
                    count++;
                }
            }
            Console.Write("\n");
        }
        Console.WriteLine("Two or more: " + count);
    }

    public class Line{
        public int startX;
        public int startY;
        public int endX;
        public int endY;
    
    }
}