using System.Linq;
public class Day8{
    string? scrambled;
    string[] scrambledArray;
    string? output;
    string[] outputArray;
    int digitCount;
    int outputArraySum;
    int[] numberSums = new int[10];

    public void Calc(){
        string path = "Days/inputDay8.txt";
        using (StreamReader sr = File.OpenText(path)){
            string? tempString;
            while ((tempString = sr.ReadLine()) != null){
                //hPositions = tempString.Split(',').Select(Int32.Parse).ToArray<int>();
                string[] splits = tempString.Split('|').ToArray<string>();
                //Console.WriteLine($"{splits[0]} and {splits[1]}");
                scrambled = splits[0];
                output = splits[1];
                scrambledArray = scrambled.Split(' ').ToArray<string>();
                outputArray = output.Split(' ').ToArray<string>();
                for (int i = 0; i < outputArray.Length; i++){
                    var asciiSum = 0;
                    if (outputArray[i].Length == 2){
                        digitCount++;
                        //foreach(char c in scrambledArray[i]){
                            //Console.WriteLine($"{c}");
                            //asciiSum += (int)c;
                        //}
                        numberSums[1] = asciiSum;
                        Console.WriteLine(numberSums[1]);
                    }
                    else if (outputArray[i].Length == 3){
                        digitCount++;
                    }
                    else if (outputArray[i].Length == 4){
                        digitCount++;
                    }
                    else if (outputArray[i].Length == 7){
                        digitCount++;
                    }
                }
            }
        }
        Console.WriteLine(digitCount);
    }
}