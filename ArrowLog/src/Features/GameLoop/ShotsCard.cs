namespace ArrowLog.Features.GameLoop;

public class ShotsCard
{
    public int MaxAttempts { get; }
    public int HitTypesAmount { get; }
    public bool IsFinished { get; set; } = false;

    public List<ShotAttempt> ShotAttempts { get; } = new();

    public event Action? OnCardFinished;

    public ShotsCard(int hitTypesAmount, int maxAttempts)
    {
        MaxAttempts = maxAttempts;
        HitTypesAmount = hitTypesAmount;
        AddNewShot();
    }

    public void HandleShot(int? targetIndex)
    {
        if (IsFinished) return;

        if (targetIndex == HitTypesAmount - 1)
        {
            if (ShotAttempts.Count < MaxAttempts)
            {
                AddNewShot();
            }
            else
            {
                FinishCard();
            }
        }
        else
        {
            FinishCard();
        }
    }

    private void AddNewShot()
    {
        var attempt = new ShotAttempt(HitTypesAmount);
        attempt.OnShotTaken += HandleShot;
        ShotAttempts.Add(attempt);
    }

    private void FinishCard()
    {
        IsFinished = true;
        OnCardFinished?.Invoke();
    }
}
