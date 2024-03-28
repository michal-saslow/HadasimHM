public abstract class Shape {
    private int height;
    private int width;

    public Shape() {
    }

    public Shape(int height, int width) {
        this.height = height;
        this.width = width;
    }

    public int getHeight() {
        return height;
    }

    public void setHeight(int height) {
        this.height = height;
    }

    public int getWidth() {
        return width;
    }

    public void setWidth(int width) {
        this.width = width;
    }

    @Override
    public String toString() {
        return "Shape{" +
                "height=" + height +
                ", width=" + width +
                '}';
    }

    public abstract void printArea();

    public abstract void printScope();
}
