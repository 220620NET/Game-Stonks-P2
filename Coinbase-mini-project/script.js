function getPrice() {
    let elem = document.getElementById('currency')
    let currencyInput = elem.value
    if(currencyInput){
        fetch('https://api.coinbase.com/v2/prices/'+ currencyInput + '-USD/spot').then((response) => response.json()).then((resBody) => {
            document.querySelector('#result-name').innerText = resBody.currency;
            document.querySelector('result-amount').innerText = resBody.amount;
        }).catch((err) => console.error(err));
    }
}