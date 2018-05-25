using Unity.Entities;


public class InputUpdateGroup  {}

[UpdateAfter(typeof(InputUpdateGroup))]
public class BehaviorUpdateGroup {}

[UpdateAfter(typeof(BehaviorUpdateGroup))]
public class PostUpdateGroup {}

