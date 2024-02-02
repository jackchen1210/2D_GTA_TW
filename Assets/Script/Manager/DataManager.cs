using UniRx;
public class DataManager : Singleton<DataManager>
{
    public ReactiveProperty<WeaponInfo> CurrentSelectWeapon { get; } = new ReactiveProperty<WeaponInfo>();
}