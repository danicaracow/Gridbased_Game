public struct GridPosition
{
    public int x { get; private set; }
    public int z { get; private set; }

    public GridPosition(int x, int z)
    {
        this.x = x;
        this.z = z;
    }

    public override string ToString()
    {
        return "x: " + x + "; z: " + z;
    }
}
