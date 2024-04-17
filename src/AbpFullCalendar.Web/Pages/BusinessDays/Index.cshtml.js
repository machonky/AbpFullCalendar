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

        var calendarDiv = document.getElementById('business_day_calendar');
        var calendar = new FullCalendar.Calendar(calendarDiv, {
            initialView: 'dayGridMonth'
        });

        calendar.render();
    };
});
