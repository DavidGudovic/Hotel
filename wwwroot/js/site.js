// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {

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

    // Initialize checkout datepicker as disabled
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
    });
});

