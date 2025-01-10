namespace ArrowLog.Features.GameLoop;

public class ShotAttempt
{
    public int? HitTarget { get; set; } = null;
    public List<string> HitOptions { get; } = new();

    public event Action<int?>? OnShotTaken;

    public ShotAttempt(int hitTypes)
    {
        for (int i = 0; i < hitTypes; i++)
        {
            HitOptions.Add(i == hitTypes - 1 ? "Miss" : $"Hit {i + 1}");
        }
    }

    public void SelectOption(int? index)
    {
        HitTarget = index;
        OnShotTaken?.Invoke(index);
    }
}
