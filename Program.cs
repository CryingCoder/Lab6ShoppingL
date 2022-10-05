namespace L6ShoppingList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DICTIONARY COLLECTION CONTAINING STRINGS AND DECIMALS FOR PRODUCT AVAILABLE AND PRICE
            Dictionary<string, decimal> shoppingList = new Dictionary<string, decimal>();

            shoppingList.Add("apple", 0.99m);
            shoppingList.Add("banana", 0.59m);
            shoppingList.Add("cauliflower", 1.59m);
            shoppingList.Add("dragonfruit", 2.19m);
            shoppingList.Add("elderberry", 1.79m);
            shoppingList.Add("figs", 2.09m);
            shoppingList.Add("grapefruit", 1.99m);
            shoppingList.Add("honeydew", 3.49m);


            //ALIGNMENT CONSTANT
            const int field = 13;
            const int field2 = -10;


            //DICTIONARY COLLECTION THAT WILL BE USED TO CONTAIN THE ITEMS THE USER SELECTS
            List<string> selectedList = new List<string>();


            //GREETING MESSAGE
            Console.WriteLine($"Welcome to Chirpus Market!\n\n Item          Price\n==============================\n");


            //FOREACH LOOP TO PRINT OUT THE LIST AT START
            foreach (KeyValuePair<string, decimal> product in shoppingList)
            {
                Console.WriteLine(($"{product.Key,field2}\t {product.Value:F2}"));
            }



            //MAIN LOOP THAT RUNS THE PROGRAM
            bool continueShopping = true;
            while (continueShopping)
            {


                //ASK WHAT THE USER WOULD LIKE TO ADD TO THEIR SHOPPING LIST AND ADD IT TO A STRING VARIABLE
                Console.WriteLine("\nWhat item would you like to order?");
                string shoppersChoice = Console.ReadLine().ToLower();


                //CREATING BOOL FROM USER INPUT TO LATER DETERMINE IF ITEM ENTERED BY USER IS IN LIST
                bool checkList = shoppingList.ContainsKey(shoppersChoice);


                //CHECK IF THE ENTERED VALUE IS IN THE DICTIONARY
                checkList = shoppingList.ContainsKey(shoppersChoice);
                if (checkList == false)
                {

                    //OUTPUT BELOW IF THE USER ENTERED VALUE IS NOT IN THE DICTIONARY
                    Console.WriteLine($"Sorry, we don't have those. Please try again.");
                    continue;
                }
                else
                {

                    //ADD USER ENTERED VALUE TO NEW LIST AND OUTPUT TO THE USER WHAT WAS ADDED
                    selectedList.Add(shoppersChoice);
                    Console.WriteLine($"\nAdding {shoppersChoice} to list at {shoppingList[shoppersChoice]}\n");
                }
                continueShopping = AskToContinue();
            }


            //GOODBYE MESSAGE AND FINAL RECEIPT OUTPUT TO CONSOLE
            Console.WriteLine($"Thanks for your order!\nHere's What you got:\n");
            Console.WriteLine($"\n Item        Price\n==============================");
            Console.WriteLine($"Your total is {TotalCost(selectedList, shoppingList)}");

        }


        //METHOD TO CALCULATE THE TOTAL COST OF THE CAR
        public static decimal TotalCost(List<string> item, Dictionary<string, decimal> productList)
        {

            //ALIGNMENT CONSTANT
            const int field = -10;


            //INITILIZING TOTAL COST VALUE TO DECIMAL VARIABLE
            decimal finalCost = 0m;


            //FOREACH LOOP TO PRINT OUT THE FINAL RECEIPT AFTER ALL ITEMS ARE ADDED TO THE LIST
            foreach (string finalItem in item)
            {
                if (productList.ContainsKey(finalItem))
                {
                    Console.WriteLine($"{finalItem,field} {productList[finalItem]}\n");
                    finalCost += productList[finalItem];
                }
            }

            return finalCost;
        }


        //METHOD TO PROMPT USER TO RERUN OR END PROGRAM
        public static bool AskToContinue()
        {
            Console.WriteLine("Would you like to order anything else (y/n)?");
            string input = Console.ReadLine().ToLower();
            if (input == "y" || input == "yes")
            {
                return true;
            }
            else if (input == "n" || input == "no")
            {
                return false;
            }
            else
            {
                Console.WriteLine("I didn't get that. Please try entering (y/n)");
                return AskToContinue();
            }
        }
    }
}