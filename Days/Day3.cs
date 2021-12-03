
public class Day3 {
    int[] gammaRate = new int[12];
    double gammaDecimal;
    int[] epsilonRate = new int[12];
    double epsilonDecimal;
    int consumption;
    string tempString;
    int[] zeroesArray = new int[12];
    int[] onesArray = new int[12];
    List<String> tempZeroes = new List<String>();
    List<String> tempOnes = new List<String>();
    int[] oxygenGeneratorRating;
    int[] co2ScrubberRating;
    int onesCount = 0;
    int zeroesCount = 0;
    List<String> workingList = new List<String>();
    
    public void Calc(){
        string path = "Days/inputDay3.txt";
        using (StreamReader sr = File.OpenText(path)){
            while ((tempString = sr.ReadLine()) != null){
                //Console.WriteLine(tempString);
                tempString.ToCharArray();
                //Console.WriteLine(tempString[0]);
                for (int i = 0; i < 12; i++){
                    if (tempString[i] == '1'){
                        onesArray[i]++;
                    }
                    else if (tempString[i] == '0'){
                        zeroesArray[i]++;
                    }                
                /*if (tempString[0] == '1'){
                    onesArray[0]++;
                }
                else if (tempString[0] == '0'){
                    zeroesArray[0]++;
                }
                
                if (tempString[1] == '1'){
                    onesArray[1]++;
                }
                else if (tempString[1] == '0'){
                    zeroesArray[1]++;
                }
                
                if (tempString[2] == '1'){
                    onesArray[2]++;
                }
                else if (tempString[2] == '0'){
                    zeroesArray[2]++;
                }
                
                if (tempString[3] == '1'){
                    onesArray[3]++;
                }
                else if (tempString[3] == '0'){
                    zeroesArray[3]++;
                }
                
                if (tempString[4] == '1'){
                    onesArray[4]++;
                }
                else if (tempString[4] == '0'){
                    zeroesArray[4]++;
                }
                  */              
                else{
                    Console.WriteLine("Shouldn't reach here");
                }

            }
        }
        for (int i = 0; i < 12; i++){
            if (onesArray[i] > zeroesArray[i]){
                gammaRate[i] = 1;
                epsilonRate[i] = 0;
            }
            else{
                gammaRate[i] = 0;
                epsilonRate[i] = 1;
            }
            Console.WriteLine(i + " : " + zeroesArray[i] + " | " + onesArray[i]);
        }
        Console.Write("\nGammaBinary: ");
        for (int i = 0; i < 12; i++){
            Console.Write(gammaRate[i]);
        }
        Console.Write("\nEpsilonBinary: ");
        for (int i = 0; i < 12; i++){
            Console.Write(epsilonRate[i]);
        }
        Console.Write("\n");
        for(int i = 0; i < 12; i++){
            gammaDecimal+= Math.Pow(2, 11-i)*gammaRate[i];
            epsilonDecimal+= Math.Pow(2, 11-i)*epsilonRate[i];
        }
            
        //gammaDecimal = Math.Pow(2,4)*gammaRate[0] + Math.Pow(2,3)*gammaRate[1] + Math.Pow(2,2)*gammaRate[2] + Math.Pow(2,1)*gammaRate[3] + Math.Pow(2,0)*gammaRate[4];
        //epsilonDecimal = Math.Pow(2,4)*epsilonRate[0] + Math.Pow(2,3)*epsilonRate[1] + Math.Pow(2,2)*epsilonRate[2] + Math.Pow(2,1)*epsilonRate[3] + Math.Pow(2,0)*epsilonRate[4];
        Console.WriteLine("GR: " + gammaDecimal + " ER: " + epsilonDecimal);
        Console.WriteLine("Consumption: " + gammaDecimal*epsilonDecimal);
        }
    }
    public void Calcp2(){
        string path = "Days/inputDay3.txt";
        using (StreamReader sr = File.OpenText(path)){
            while ((tempString = sr.ReadLine()) != null){
                //Console.WriteLine(tempString);
                tempString.ToCharArray();
                //Console.WriteLine(tempString[0]);
              
                if (tempString[0] == '1'){
                    tempOnes.Add(tempString);
                    
                }
                else if (tempString[0] == '0'){
                    tempZeroes.Add(tempString);
                }
            }
        }
        if (tempOnes.Count > tempZeroes.Count){
            workingList = tempOnes;
            Console.WriteLine("ones: " + workingList.Count);
        }
        else{
            workingList = tempZeroes;
            Console.WriteLine("zeroes: " + workingList.Count);
        }
        Console.WriteLine(workingList.ElementAt(index:0));
    }
}