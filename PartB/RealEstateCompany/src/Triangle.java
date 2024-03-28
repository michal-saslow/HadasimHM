public class Triangle extends Shape {
    public Triangle(int height, int width) {
        super(height, width);
    }

    public Triangle() {
    }

    @Override
    public void printArea() {
        int numberOfRowsToPrint = (int) ((getHeight() - 2) / (int) ((getWidth() - 2) / 2));
        int additionalRowsToPrint = (int) ((getHeight() - 2) % (int) ((getWidth() - 2) / 2));
        int numberOfCharsToPrint = 1;
        printRowsOfChars(1, ((getWidth() - numberOfCharsToPrint) / 2), numberOfCharsToPrint);
        for (numberOfCharsToPrint += 2; numberOfCharsToPrint < getWidth(); numberOfCharsToPrint += 2) {
            if (numberOfCharsToPrint == 3) {
                printRowsOfChars(additionalRowsToPrint, ((getWidth() - numberOfCharsToPrint) / 2), numberOfCharsToPrint);
            }
            printRowsOfChars(numberOfRowsToPrint, ((getWidth() - numberOfCharsToPrint) / 2), numberOfCharsToPrint);
        }
        printRowsOfChars(1, 0, getWidth());
    }

    private void printRowsOfChars(int numberOfRows, int numberOfSpacing, int numberOfChars) {
        for (int i = 0; i < numberOfRows; i++) {
            for (int j = 0; j < numberOfSpacing; j++) {
                System.out.print(" ");
            }
            for (int j = 0; j < numberOfChars; j++) {
                System.out.print("*");
            }
            System.out.println();
        }
    }

    @Override
    public void printScope() {
        //according to the Pythagorean theorem
        double altitude = Math.sqrt(Math.pow(getHeight(), 2) + Math.pow((getWidth() / 2), 2));
        System.out.println("The perimeter of the triangle is: " + (getWidth() + 2 * altitude));
    }
}
