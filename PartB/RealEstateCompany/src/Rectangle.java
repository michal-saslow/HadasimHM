public class Rectangle extends Shape {
    public Rectangle(int height, int width) {
        super(height, width);
    }

    public Rectangle() {
    }

    @Override
    public void printArea() {
        System.out.println("The area of the rectangle is: " + getHeight() * getWidth());
    }

    @Override
    public void printScope() {
        System.out.println("The perimeter of the rectangle is: " + (2 * getWidth() + 2 * getHeight()));
    }
}
