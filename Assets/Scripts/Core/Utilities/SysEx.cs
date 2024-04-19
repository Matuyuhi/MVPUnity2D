namespace Core.Utilities
{
    public static class SysEx
    {
        public static class Unity
        {
            public static float ToDeltaTime => UnityEngine.Time.deltaTime * 1_000f;
        }
        // TODO: Implement System environment getter
    }
}