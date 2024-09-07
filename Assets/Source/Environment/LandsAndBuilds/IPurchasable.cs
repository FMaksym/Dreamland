using System.Collections.Generic;

public interface IPurchasable
{
    bool IsActive { get; set; }
    bool IsPurchased { get; set; }
    bool MainObjectActive { get; set; }
    bool PriceObjectActive { get; set; }
    string MainObjectName { get; set; }
    Dictionary<string, int> Price { get; set; }

    public bool ObjectIsActive();
}
