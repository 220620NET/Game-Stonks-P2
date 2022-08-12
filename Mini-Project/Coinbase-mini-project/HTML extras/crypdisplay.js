function priceFetcher(){
    const reqArr = [
    'https://api.coinbase.com/v2/prices/BTC-USD/spot',
    'https://api.coinbase.com/v2/prices/ETH-USD/spot',
    'https://api.coinbase.com/v2/prices/USDT-USD/spot',
    'https://api.coinbase.com/v2/prices/USDC-USD/spot',
    'https://api.coinbase.com/v2/prices/ETH2-USD/spot',
    'https://api.coinbase.com/v2/prices/DOGE-USD/spot',
    'https://api.coinbase.com/v2/prices/BUSD-USD/spot',
    'https://api.coinbase.com/v2/prices/ADA-USD/spot',
    'https://api.coinbase.com/v2/prices/SOL-USD/spot',
    'https://api.coinbase.com/v2/prices/DOT-USD/spot'
    ]
    Promise.all(reqArr.map((url) => fetch(url).then((response) => response.json()))).then((resBody) => {
        console.log(resBody);
        resBody.forEach(displayupdater);
    })
}
function displayupdater(data){
    const basestring = data.data.base;
    document.querySelector('#' + basestring).innerText = data.data.amount;
    document.querySelector('#' + basestring + 'Currency').innerText = data.data.currency;
}
