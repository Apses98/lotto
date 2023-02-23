# Lotto Program

This program allows the user to play the lottery by generating random lotto rows and comparing them to the user-submitted lotto row. 

## Namespace: `lotto`

### Class: `lotto : Form`

#### Constants
- `PRECENT`: 100
- `LOTTO_ROW_SIZE`: 7
- `MAX_DRAWING_SIZE`: 999999
- `MAX_LOTTO_SIZE`: 36

#### Methods

##### `public lotto()`
- Constructor for the `lotto` class

##### `private void starta_lotto_button_Click(object sender, EventArgs e)`
- Event handler for the "Starta Lotto" button
- Calls `checkDrawingNumber()` and `checkLottoNumber()` before executing `lottoDrawing()`

##### `private void updateProgressBar(int numberOfDrawingsLeft)`
- Updates the progress bar on the form based on the number of drawings left
- Takes one `int` parameter, `numberOfDrawingsLeft`

##### `private int[] generateRandomLotto()`
- Generates a random lotto row of 7 integers between 1 and 35
- Checks for duplicates and generates new numbers until all numbers in the row are unique
- Returns an array of 7 random integers

##### `private int[] getLottoNumber()`
- Gets numbers submitted by the user and returns them as an int-array
- Reads from `lotto_textbox1` through `lotto_textbox7`

##### `private void lottoDrawing()`
- Main function for generating lotto rows and comparing them to the user-submitted lotto row
- Gets the number of drawings requested by the user and the user-submitted lotto row
- Generates random sets of 7 numbers (lotto rows) and checks if they match the user-submitted lotto row
- Counts the number of matches and updates the progress bar
- Displays the results on the form

#### Helper Functions

##### `private bool checkDrawingNumber()`
- Checks if the number of drawings requested by the user is valid
- Displays an error message if the input is invalid
- Returns `true` if the input is valid, `false` otherwise

##### `private bool checkLottoNumber()`
- Checks if the user-submitted lotto row is valid
- Displays an error message if the input is invalid
- Returns `true` if the input is valid, `false` otherwise

## Usage

To use the program, follow these steps:

1. Enter the number of drawings you want to play in the `antaldragningar_textBox` text box.
2. Enter your lotto numbers in the `lotto_textbox1` through `lotto_textbox7` text boxes.
3. Click the "Starta Lotto" button to start playing.
4. Wait for the program to generate lotto rows and compare them to your numbers.
5. The program will display the number of times you matched 5, 6, or 7 numbers, as well as the progress bar showing how many drawings are left.
6. You can play again by repeating steps 2-5.
