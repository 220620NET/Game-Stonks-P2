fetch('https://api.coingecko.com/api/v3/simple/price?ids=binancecoin%2Cbinance-usd%2Cbitcoin%2Ccardano%2Cdogecoin%2Cethereum%2Cpolkadot%2Csolana%2Ctether%2Cusd-coin&vs_currencies=usd&include_24hr_change=true&include_last_updated_at=true')
  .then((response) => response.json())
  .then((data) => console.log(data));
