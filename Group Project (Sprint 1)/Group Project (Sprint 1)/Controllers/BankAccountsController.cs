using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class BankAccountsController : ControllerBase
{
    private static List<BankAccount> _accounts = new List<BankAccount>()
    {
        new BankAccount { AccountNumber = 1, Name = "John Doe", TotalBalance = 5000, WithdrawAmount = 1000 },
        new BankAccount { AccountNumber = 2, Name = "Jane Smith", TotalBalance = 10000, WithdrawAmount = 2000 },
        new BankAccount { AccountNumber = 3, Name = "Bob Johnson", TotalBalance = 7500, WithdrawAmount = 1500 }
    };

    // GET api/bankaccounts
    [HttpGet]
    public IActionResult GetBankAccounts()
    {
        var result = _accounts.Select(account => new
        {
            AccountNumber = account.AccountNumber,
            Name = account.Name,
            TotalBalance = account.TotalBalance,
            RemainingBalance = account.TotalBalance - account.WithdrawAmount
        });
        return Ok(result);
    }

    // GET api/bankaccounts/5
    [HttpGet("{id}")]
    public IActionResult GetBankAccount(int id)
    {
        var account = _accounts.FirstOrDefault(a => a.AccountNumber == id);
        if (account == null)
        {
            return NotFound();
        }
        return Ok(new
        {
            AccountNumber = account.AccountNumber,
            Name = account.Name,
            TotalBalance = account.TotalBalance,
            RemainingBalance = account.TotalBalance - account.WithdrawAmount
        });
    }

    // POST api/bankaccounts
    [HttpPost]
    public IActionResult PostBankAccount([FromBody] BankAccount account)
    {
        if (ModelState.IsValid && account.AccountNumber != null && account.Name != null && account.TotalBalance != null && account.WithdrawAmount != null)
        {
            _accounts.Add(account);
            return CreatedAtAction(nameof(GetBankAccount), new { id = account.AccountNumber }, new
            {
                AccountNumber = account.AccountNumber,
                Name = account.Name,
                TotalBalance = account.TotalBalance,
                WithdrawAmount = account.WithdrawAmount
            });
        }
        return BadRequest(ModelState);
    }

    // PUT api/bankaccounts/5
    [HttpPut("{id}")]
    public IActionResult PutBankAccount(int id, [FromBody] BankAccount account)
    {
        if (ModelState.IsValid && id == account.AccountNumber && account.Name != null && account.TotalBalance != null && account.WithdrawAmount != null)
        {
            var existingAccount = _accounts.FirstOrDefault(a => a.AccountNumber == id);
            if (existingAccount == null)
            {
                return NotFound();
            }
            existingAccount.Name = account.Name;
            existingAccount.TotalBalance = account.TotalBalance;
            existingAccount.WithdrawAmount = account.WithdrawAmount;
            return Ok(new
            {
                AccountNumber = existingAccount.AccountNumber,
                Name = existingAccount.Name,
                TotalBalance = existingAccount.TotalBalance,
                WithdrawAmount = existingAccount.WithdrawAmount
            });
        }
        return BadRequest(ModelState);
    }

    // DELETE api/bankaccounts/5
    [HttpDelete("{id}")]
    public IActionResult DeleteBankAccount(int id)
    {
        var account = _accounts.FirstOrDefault(a => a.AccountNumber == id);
        if (account == null)
        {
            return NotFound();
        }
        _accounts.Remove(account);
        return Ok();
    }
}
