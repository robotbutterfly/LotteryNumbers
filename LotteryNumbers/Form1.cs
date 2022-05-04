using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LotteryNumbers
{
    public partial class Form1 : Form
    {
        int mode = 2; // 1 for no array, 2 with array

        public Form1()
        {
            InitializeComponent();
        }

        private void calcButton_Click(object sender, EventArgs e)
        {
            if (mode == 1)
            {
                noList();
            }
            else
            {
                withList();
            }

        }

        public void noList()
        {
            const int LIMIT = 50;

            int num1, num2, num3, num4, num5, num6;

            Random randGen = new Random();

            //get first value
            num1 = randGen.Next(1, LIMIT);

            //get second value and if not unique keep getting
            num2 = randGen.Next(1, LIMIT);

            while (num2 == num1)
            {
                num2 = randGen.Next(1, LIMIT);
            }

            //get third value and if not unique keep getting
            num3 = randGen.Next(1, LIMIT);

            while (num3 == num1 || num3 == num2)
            {
                num3 = randGen.Next(1, LIMIT);
            }

            //get fourth value and if not unique keep getting
            num4 = randGen.Next(1, LIMIT);

            while (num4 == num1 || num4 == num2 || num4 == num3)
            {
                num4 = randGen.Next(1, LIMIT);
            }

            //get fifth value and if not unique keep getting
            num5 = randGen.Next(1, LIMIT);

            while (num5 == num1 || num5 == num2 || num5 == num3 || num5 == num4)
            {
                num5 = randGen.Next(1, LIMIT);
            }

            //get sixth value and if not unique keep getting
            num6 = randGen.Next(1, LIMIT);

            while (num6 == num1 || num6 == num2 || num6 == num3 || num6 == num4 || num6 == num5)
            {
                num6 = randGen.Next(1, LIMIT);
            }

            outputLabel.Text = "Your winning numbers: \n" +
                num1 + " " + num2 + " " + num3 + " " + num4 + " " + num5 + " " + num6;
        }

        public void withList()
        {
            const int LIMIT = 50; // LIMIT must be one more than the possible top value

            List<int> numbers = new List<int>();
            Random randGen = new Random();
            int newNum;

            //add the first value to the list
            numbers.Add(randGen.Next(1, LIMIT));

            //get values 2 to 6
            for (int i = 2; i <= 6; i++)
            {
                newNum = randGen.Next(1, LIMIT);

                //keep getting a new value until one is found that is unique
                while (numbers.Contains(newNum))
                {
                    newNum = randGen.Next(1, LIMIT);
                }

                //add new unique value to the list
                numbers.Add(newNum);
            }

            //sort the list and prep the output are for new output
            numbers.Sort();
            outputLabel.Text = "";

            //display winning numbers
            foreach(int i in numbers)
            {
                outputLabel.Text = outputLabel.Text + " " + i;
            }
        }
    }
}
