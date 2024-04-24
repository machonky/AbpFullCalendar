$(function () {
    abp.log.debug('BusinessDays/Index.cshtml.js initialized!');

    if (document.readyState !== 'loading') {
        initCalendar();
    } else {
        document.addEventListener('DOMContentLoaded', function () {
            initCalendar();
        });
    }

    function initCalendar() {
        var l = abp.localization.getResource('AbpFullCalendar');

        var minSelectableDate = null;
        abpFullCalendar.businessDays.businessDay.getMinSelectableBusinessDate()
            .then(data => {
                minSelectableDate = new Date(data.date);
            })
            .then(_ => {
                initCalendarContinuation();
            })
            .catch(error => {
                console.error('Error:', error);
            });        

        function initCalendarContinuation() {

            var calendarDiv = document.getElementById('business_day_calendar');
            var calendar = new FullCalendar.Calendar(calendarDiv, {
                headerToolbar: {
                    left: '',
                    center: 'title',
                    right: 'prev,next today dayGridMonth,multiMonthYear'
                },
                initialView: 'dayGridMonth',
                editable: false, // Don't allow to modify events on the UI
                selectable: true, // Allow multiple selection of dates
                selectAllow: selectAllowCallback,
                events: requestEvents,
                select: selectCallback
            });

            function selectAllowCallback(selectInfo) {
                // Dynamically determine if a cell can be selected.
                // https://fullcalendar.io/docs/selectAllow

                return selectInfo.start > minSelectableDate;
            };

            function requestEvents(fetchInfo, successCallback, failureCallback) {
                // Get the start and end dates of the visible date range
                var startDate = fetchInfo.start.toISOString();
                var endDate = fetchInfo.end.toISOString();

                // Use the JS Dynamic Proxy to the app service
                abpFullCalendar.businessDays.businessDay
                    .getBusinessDays(startDate, endDate)
                    .then(data => {
                        successCallback(data);
                    })
                    .catch(error => {
                        failureCallback(error);
                    });
            };

            function selectCallback(info) {
                var startDate = info.startStr;
                var endDate = info.endStr;

                // Use the JS Dynamic Proxy to the app service
                abpFullCalendar.businessDays.businessDay
                    .storeBusinessDays({ startDate: startDate, endDate: endDate })
                    .then(data => {
                        if (data.success) {
                            // Refetch the events and rerender the calendar
                            calendar.refetchEvents();
                        }
                    })
                    .catch(error => {
                        // Handle any errors
                        console.error('Error:', error);
                    });
            };

            calendar.render();
        };
    };
});
