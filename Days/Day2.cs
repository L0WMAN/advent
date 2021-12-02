public class Day2 {
    int horizontal;
    int vertical;
    int aim;
    string tempString;
    public void Calc(){
        string path = "Days/inputDay2.txt";
        using (StreamReader sr = File.OpenText(path)){
            while ((tempString = sr.ReadLine()) != null){
                //Console.WriteLine(tempString);
                tempString.ToCharArray();
                Console.WriteLine(tempString[0]);
                string[] splits = tempString.Split(' ');
                var value = Int32.Parse(splits[1]);
                //Console.WriteLine(value);
                if (tempString[0] == 'd'){
                    aim+=value;
                }
                else if (tempString[0] == 'u'){
                    aim-=value;
                }
                else if (tempString[0] == 'f'){
                    horizontal+=value;
                    vertical = vertical + aim*value;
                }
                else{
                    Console.WriteLine("Shouldn't reach here");
                }

            }
        }
        Console.WriteLine("Horizontal: " + horizontal + " Vertical: " + vertical);
        Console.WriteLine("Multiplied: " + horizontal*vertical);
    }
}