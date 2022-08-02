$('#exchangerates').append('<div id="rates"></div><div id="reload"></div>');

function loadRates() {
  $.getJSON('https://api.coingecko.com/api/v3/simple/price?ids=binancecoin%2Cbinance-usd%2Cbitcoin%2Ccardano%2Cdogecoin%2Cethereum%2Cpolkadot%2Csolana%2Ctether%2Cusd-coin&vs_currencies=usd&include_24hr_change=true&include_last_updated_at=true')
  .done( function(data){                                 // SERVER RETURNS DATA
    //var d = new Date();                                  // Create date object
    //var hrs = d.getHours();                              // Get hours
    //var mins = d.getMinutes();                           // Get mins
    var msg = '<h2>Exchange Rates</h2>';                 // Start message
    $.each(data, function(key, val) {                    // Add each rate
      msg += '<div class="' + key + '">' + key + ': ' + val + '</div>';
    });
    msg += '<br>Last update: ' + hrs + ':' + mins + '<br>'; // Show update time
    $('#rates').html(msg);                               // Add rates to page
  }).fail( function() {                                  // THERE IS AN ERROR
    $('#rates').text('Sorry, we cannot load rates.');   // Show error message 
  }).always( function() {                                // ALWAYS RUNS
     var reload = '<a id="refresh" href="#">';           // Add refresh link
     //reload += '<img src="img/refresh.png" alt="refresh" /></a>';
     reload += '<input type="submit" name="getStats" value="Get Stats" />';
     $('#reload').html(reload);                          // Add refresh link
     $('#refresh').on('click', function(e) {             // Add click handler
       e.preventDefault();                               // Stop link
       loadRates();                                      // Call loadRates()
     });
  }); 
}

loadRates();