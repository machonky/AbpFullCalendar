$(function () {
    if (document.readyState !== 'loading') {
        initCalendar();
    } else {
        document.addEventListener('DOMContentLoaded', function () {
            initCalendar();
        });
    }

    function initCalendar() {
        var l = abp.localization.getResource('AbpFullCalendar');

        var calendarDiv = document.getElementById('calendar');
        var calendar = new FullCalendar.Calendar(calendarDiv, {
            initialView: 'dayGridMonth'
        });

        calendar.render();
    };
});
