[System.Serializable]
public class EventArgs<TSender>
{
    public TSender sender;
}

[System.Serializable]
public class EventArgs<TSender, T0>
{
    public TSender sender;
    public T0 paramter0;
}

[System.Serializable]
public class EventArgs<TSender, T0, T1>
{
    public TSender sender;
    public T0 paramter0;
    public T1 paramter1;
}

[System.Serializable]
public class EventArgs<TSender, T0, T1, T2>
{
    public TSender sender;
    public T0 paramter0;
    public T1 paramter1;
    public T2 paramter2;
}

[System.Serializable]
public class EventArgs<TSender, T0, T1, T2, T3>
{
    public TSender sender;
    public T0 paramter0;
    public T1 paramter1;
    public T2 paramter2;
    public T3 paramter3;
}
