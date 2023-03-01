/*
 * 
 * Script updates the subtotal and total price on the page and provides the datepicker functionalities
 * 
 */ 
$(document).ready(function () {
    //Start the datepicker as disabled
    $('#checkout').prop('disabled', true);

    // Initialize checkin datepicker
    $('#checkin').datepicker({
        format: 'yyyy-mm-dd',
        startDate: new Date(),
        endDate: moment().add(1, 'year').toDate(),
        beforeShowDay: function (date) {
            var dateStr = moment(date).format('YYYY-MM-DD');
            return {
                enabled: !bookedDates.includes(dateStr)
            };
        },
        autoclose: true
    }).on('changeDate', function (e) {
        var startDate = e.date;
        var endDatePicker = $('#checkout');
        // Enable checkoutpicker
        endDatePicker.prop('disabled', false);
        updatePrices();
        // Set checkout datepicker start date to checkin date
        endDatePicker.datepicker('setStartDate', startDate);

        // Find next unavailable date after checkin date
        var nextUnavailableDate = bookedDates.find(function (date) {
            return moment(date) > moment(startDate);
        });

        // Set checkout datepicker end date to next unavailable date
        if (nextUnavailableDate) {
            endDatePicker.datepicker('setEndDate', moment(nextUnavailableDate).toDate());
        } else {
            endDatePicker.datepicker('setEndDate', moment().add(1, 'year').toDate());
        }
        //Set the checkout date to checkin date
        endDatePicker.datepicker('setDate', startDate);
    });

    // Checkout datepicker
    $('#checkout').datepicker({
        format: 'yyyy-mm-dd',
        startDate: new Date(),
        endDate: moment().add(1, 'year').toDate(),
        beforeShowDay: function (date) {
            var dateStr = moment(date).format('YYYY-MM-DD');
            return {
                enabled: !bookedDates.includes(dateStr)
            };
        },
        autoclose: true
    }).on('changeDate', function (e) {
        updatePrices();
    });




    // PRICE UPDATE

    // Get the HTML elements
    var checkinInput = $('#checkin');
    var checkoutInput = $('#checkout');
    var guestsInput = $('#guests');
    var couponInput = $('#coupon');
    var subtotalSpan = $('#subtotal');
    var totalSpan = $('#total');

    // Calculate the initial subtotal and total price
    var startDate = checkinInput.datepicker('getDate');
    var endDate = checkoutInput.datepicker('getDate');
    var numDays = (endDate - startDate) / (1000 * 60 * 60 * 24) + 1;
    var numGuests = guestsInput.val();

    var subtotal = numDays * numGuests * pricePerDay;
    var coupon = couponInput.val();
    var total = calculateTotal(subtotal, coupon);

    // Update the initial values in the span elements
    subtotalSpan.text(subtotal.toFixed(2));
    totalSpan.text(total.toFixed(2));

    // Add event listeners to update the subtotal and total price when the date range, number of guests, or coupon changes
    guestsInput.change(updatePrices);
    couponInput.change(updatePrices);

    function updatePrices() {
        // Calculate the new subtotal and total price
        var startDate = checkinInput.datepicker('getDate');
        var endDate = checkoutInput.datepicker('getDate');
        var numDays = Math.round((endDate - startDate) / (1000 * 60 * 60 * 24) + 1);
        var numGuests = Math.round(guestsInput.val());
        var subtotal = Math.round(numDays * numGuests * pricePerDay);
        var coupon = couponInput.val();
        var total = calculateTotal(subtotal, coupon);

        // Update the values in the span elements
        subtotalSpan.text(subtotal.toFixed(2));
        totalSpan.text(total.toFixed(2));
    }

    function calculateTotal(subtotal, coupon) {
        // Calculate the total price after the coupon discount
        var discount = 0;
        if (coupon.length == 8) {
            discount = 10; // 10% discount for valid coupon
        }
        var total = subtotal - (subtotal * discount / 100);
        console.log(total);
        return total;
    }

});

