public class Day1
{
            int count = 0;
            string? tempString;
            int tempA = 0;
            int tempB = 0;
            int tempC = 0;
            int window1 = 0;
            int window2 = 10000;               
                
public void Calc(){
    string path = "Days/inputDay1.txt";
    using (StreamReader sr = File.OpenText(path)){

            try{
                while ((tempString = sr.ReadLine()) != null){
                    tempA = Int32.Parse(tempString);
                    window1 = tempA + tempB + tempC;
                    //Console.WriteLine("temp1: " + temp1);
                    if (tempC != 0){
                    
                        if (window2 < window1){
                            Console.WriteLine(window1);
                            count++;
                        }
                        window2 = window1;
                    }
                    tempC = tempB;
                    tempB = tempA;     
                }
            }
                catch (Exception e) {
                    Console.WriteLine(e);
                }
            Console.WriteLine(count);
        }
}
}