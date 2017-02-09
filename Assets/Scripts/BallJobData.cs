using System;
using System.Collections.Generic;   

[Serializable]
public class BallJobData
{
    public BallJob job;
    
    public float minRadius;
    public float maxRadius;

    public float minWeight;
    public float maxWeight;

    public float minGloss;
    public float maxGloss;

    public float minElasticity;
    public float maxElasticity;

    public string potraitPath;
    public string descriptKey;
}

[Serializable]
public class BallJobList
{
    public List<BallJobData> list;
}