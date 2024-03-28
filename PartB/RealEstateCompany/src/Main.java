import java.util.Scanner;

// Press Shift twice to open the Search Everywhere dialog and type `show whitespaces`,
// then press Enter. You can now see whitespace characters in your code.
public class Main {

    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        Shape shape;
        printMenu();
        int choice = in.nextInt();
        int choiceTriangle;
        while (choice != 3) {
            switch (choice) {
                case 1:
                    shape = new Rectangle();
                    createShape(shape);
                    if (shape.getHeight() == shape.getWidth() || Math.abs(shape.getHeight() - shape.getWidth()) > 5)
                        shape.printArea();
                    else
                        shape.printScope();
                    break;
                case 2:
                    shape = new Triangle();
                    createShape(shape);
                    printMenuTriangle();
                    choiceTriangle = in.nextInt();
                    switch (choiceTriangle) {
                        case 1:
                            shape.printScope();
                            break;
                        case 2:
                            if (shape.getWidth() % 2 == 0 || shape.getWidth() > shape.getHeight() * 2 || shape.getWidth() < 5)
                                System.out.println("The triangle cannot be printed");
                            else
                                shape.printArea();
                            break;
                        default:
                            System.out.println("Your choice is wrong");
                            break;
                    }
                    break;
                default:
                    System.out.println("Your choice is wrong");
                    break;
            }
            printMenu();
            choice = in.nextInt();
        }
    }

    public static void createShape(Shape shape) {
        Scanner in = new Scanner(System.in);
        System.out.println("Enter height and width");
        shape.setHeight(in.nextInt());
        shape.setWidth(in.nextInt());
        while (shape.getHeight() < 2 || shape.getWidth() < 2) {
            System.out.println("The input must be greater than 2,please enter again");
            shape = new Rectangle(in.nextInt(), in.nextInt());
        }
    }

    public static void printMenu() {
        System.out.println("Enter 1 to select a rectangular tower");
        System.out.println("Enter 2 to select a triple tower");
        System.out.println("Enter 3 to exit");
    }

    public static void printMenuTriangle() {
        System.out.println("Enter 1 to calculate the perimeter of the triangle");
        System.out.println("Insert 2 to print the triangle");
    }

}