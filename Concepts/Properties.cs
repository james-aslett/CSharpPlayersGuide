class MyClass
{
    private float _width;
    public float _height;

    //properties automatically include a specicial 'value' variable, so we don't need to define one
    public float WidthExpressionBody
    {
        get => _width;
        set => _width = value;
    }

    public float WidthBlockBody
    {
        get
        {
            return _width;
        }
        set
        {
            _width = value;
        }
    }

    //get-only properties make sense for something that can't be changed from the outside
    public float Area
    {
        get => _width * _height;
    }

    //if the property is get-only with an expression body like above, we can simplify it further
    public float AreaSimple => _width * _height;

}