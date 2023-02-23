namespace lotto
{
    
    public partial class lotto : Form
    {
        // Constants
        private const int PRECENT = 100, LOTTO_ROW_SIZE = 7, MAX_DRAWING_SIZE = 999999, MAX_LOTTO_SIZE = 36;
        public lotto()
        {
            InitializeComponent();
        }

        private void starta_lotto_button_Click(object sender, EventArgs e)
        {
            // Check if the drawing number and the lotto number are valid
            if (checkDrawingNumber() && checkLottoNumber())
            {
                // Then excute the function lottoDrawing();
                lottoDrawing();
            } 
        }
        private void updateProgressBar(int numberOfDrawingsLeft)
        {
            // updateProgressBar function takes one int parameter which is the number of drawings left
            // Calculate the precentage result (decremental).
            int result = (numberOfDrawingsLeft * PRECENT) / int.Parse(antaldragningar_textBox.Text);
            // The progress in precent (incremental)
            result = PRECENT - result;
            // Display the result using the progressBar
            progressBar.Value = result;
            
        }
        private int[] generateRandomLotto()
        {
            // Generates a random array of 7 int(s) with a value between 1 -35
            int[] generatedLotto = new int[LOTTO_ROW_SIZE];
            Random rand =  new Random();
            for (int i = 0; i < LOTTO_ROW_SIZE; i++)
            {
                generatedLotto[i] = rand.Next(1, MAX_LOTTO_SIZE);
            }
            // Check for dubblicates
            for (int i = 0; i < LOTTO_ROW_SIZE;i++ )
            {
                for (int j = 0; j < LOTTO_ROW_SIZE; j++)
                {
                    if (generatedLotto[i] == generatedLotto[j] && i != j)
                    {
                        // If dubblicates found generate a new number then recheck!
                        generatedLotto[i] = rand.Next(1, MAX_LOTTO_SIZE);
                        j = -1;
                    }
                    
                }
            }
            // returns an array of 7 random int(s)
            return generatedLotto;
        }
        private int[] getLottoNumber()
        {
            // Gets numbers submitted by the user and returns them as an int-array.
            int[] lottoNumber = new int[LOTTO_ROW_SIZE];
            lottoNumber[0] = int.Parse(lotto_textbox1.Text);
            lottoNumber[1] = int.Parse(lotto_textbox2.Text);
            lottoNumber[2] = int.Parse(lotto_textbox3.Text);
            lottoNumber[3] = int.Parse(lotto_textbox4.Text);
            lottoNumber[4] = int.Parse(lotto_textbox5.Text);
            lottoNumber[5] = int.Parse(lotto_textbox6.Text);
            lottoNumber[6] = int.Parse(lotto_textbox7.Text);
            return lottoNumber;
        }
        private void lottoDrawing()
        {
            /*
             * lottoDrawing function:
             * 1- Gets the number of drawings requested by the user [ numberOfDrawings ]
             * 2- Gets the number of lotto row submited by the user [ lottoNumber ]
             * 3- Generates random sets of 7 numbers (lotto Rows) and checks if it match the numbers of lotto row submited by the user [ lottoNumber ]
             * 4- Registers if 5, 6 or seven numbers match
             * 5- Updates the progressBar
             * 6- Displays the results. 
             **/
            int numberOfDrawings = int.Parse(antaldragningar_textBox.Text), fiveRight = 0, sixRight = 0, sevenRight = 0, rightCounter = 0;
            int[] lottoNumber = getLottoNumber();
            int[] generatedLotto;
            
            while (numberOfDrawings != 0)
            {
                rightCounter = 0;
                generatedLotto = generateRandomLotto();

                for (int i = 0; i < LOTTO_ROW_SIZE; i++)
                {
                    for (int j = 0; j < LOTTO_ROW_SIZE; j++)
                    {
                        if (lottoNumber[i] == generatedLotto[j])
                        {
                            rightCounter++;
                        }
                    }
                }

                if (rightCounter == 5)
                {
                    fiveRight++;
                }
                else if (rightCounter == 6)
                {
                    sixRight++;        
                }
                else if (rightCounter == 7)
                {
                    sevenRight++;
                }
                numberOfDrawings--;
                updateProgressBar(numberOfDrawings);
            }

            textBox_7_ratt.Text = $"{sevenRight}";
            textBox_6_ratt.Text = $"{sixRight}";
            textBox_5_ratt.Text = $"{fiveRight}";

            if (sevenRight > 0)
            {
                textBox_7_ratt.BackColor = Color.LightGreen;
            }else
                textBox_7_ratt.BackColor = Color.LightCoral;

            if (sixRight > 0)
            {    
                textBox_6_ratt.BackColor = Color.LightGreen;
            }
            else
                textBox_6_ratt.BackColor = Color.LightCoral;

            if (fiveRight > 0)
            {
                textBox_5_ratt.BackColor = Color.LightGreen;
            }
            else
                textBox_5_ratt.BackColor = Color.LightCoral;
            
            
        }
        private bool checkDrawingNumber()
        {
            /*
             * chckDrawingNumber function:
             * 1- Checks if the user submited a valid drawing number (only numbers) between (1 - 999999), and displays error messages if there is an error.
             **/
            try
            {
                if (int.Parse(antaldragningar_textBox.Text) < 1 || int.Parse(antaldragningar_textBox.Text) > MAX_DRAWING_SIZE)
                {
                    MessageBox.Show("Antalet Dragningarna är felaktigt!!\nDet måste vara mellan 1 och 999999");
                    return false;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Antalet dragningar kan bara vara heltal mellan 1 och 999999.");
                return false;
            }
            catch (OverflowException)
            {
                MessageBox.Show($" Fel Inmatning,\n prova något annat mellan 1 - 999999!");
                return false;
            }
            catch ( Exception e)
            {
                MessageBox.Show($"Error: {e.Message}");
                return false;
            }
            
            return true;
        }


        private bool checkLottoNumber()
        {
            /*
             * chckLottoNumber function:
             * 1- Checks if the user submited a valid set of numbers (only numbers) between (1 - 35), and displays error messages if there is an error.
             **/
            int[] lottoNumber = new int[LOTTO_ROW_SIZE];
            try
            {
                lottoNumber = getLottoNumber();
            }
            catch (FormatException)
            {
                MessageBox.Show("Fel Inmatning!!\nDet är inte tillåtet att ha bokstaver, symboler eller tomma fält i din lottorad!!\n Bara hela positiva tal mellan 1 och 35 är tillåtna!!");
                return false;
            }
            catch (OverflowException)
            {
                MessageBox.Show($" Fel inmatning,\n prova något annat mellan 1 - 35!");
                return false;
            }
            catch(Exception e)
            {
                MessageBox.Show($"Error: {e.Message}");
                return false;
            }

            for (int i = 0; i < LOTTO_ROW_SIZE; i++)
            {
                if (lottoNumber[i] < 1 || lottoNumber[i] > MAX_LOTTO_SIZE - 1)
                {
                    MessageBox.Show($"Fel Inmatning i din lottorad i textbox nummer {i+1}!!\nI din lottorad kan du bara mata in tal mellan 1 och 35.");
                    return false;
                }
                for (int j = 0; j < LOTTO_ROW_SIZE; j++)
                {
                    if (lottoNumber[i] == lottoNumber[j] && j != i)
                    {
                        MessageBox.Show($"Fel Inmatning i din lottorad!!\nDu har dubbletter, det är inte tillåtit!!");
                        return false;
                    }
                }   
            }
            return true;
        }

        private void generate_random_button_Click(object sender, EventArgs e)
        {
            generateRandomInputs();
        }

        private void generateRandomInputs()
        {
            // generateRandomInputs generates random lotto numbers and random deawing number!!
            // Between 1 - 35 and no dubblicates
            int[] generatedInputs = new int[LOTTO_ROW_SIZE];
            Random rand = new Random();
            for (int i = 0; i < LOTTO_ROW_SIZE; i++)
            {
                generatedInputs[i] = rand.Next(1, MAX_LOTTO_SIZE);
            }
            // Check for dubblicates
            for (int i = 0; i < LOTTO_ROW_SIZE; i++)
            {
                for (int j = 0; j < LOTTO_ROW_SIZE; j++)
                {
                    if (generatedInputs[i] == generatedInputs[j] && i != j)
                    {
                        generatedInputs[i] = rand.Next(1, MAX_LOTTO_SIZE);
                        j = -1;
                    }
                }
            }
            // Display the generated Randoms
            lotto_textbox1.Text = $"{generatedInputs[0]}";
            lotto_textbox2.Text = $"{generatedInputs[1]}";
            lotto_textbox3.Text = $"{generatedInputs[2]}";
            lotto_textbox4.Text = $"{generatedInputs[3]}";
            lotto_textbox5.Text = $"{generatedInputs[4]}";
            lotto_textbox6.Text = $"{generatedInputs[5]}";
            lotto_textbox7.Text = $"{generatedInputs[6]}";
            antaldragningar_textBox.Text = $"{rand.Next(1, MAX_DRAWING_SIZE + 1 )}";
        }
    }
}