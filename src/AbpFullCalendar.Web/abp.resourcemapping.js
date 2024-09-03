module.exports = {
    aliases: {
        "@node_modules": "./node_modules",
        "@libs": "./wwwroot/libs"
    },
    clean: [
        "@libs"
    ],
    mappings: {
        "@node_modules/fullcalendar/index.global.min.js": "@libs/fullcalendar"
    }
};
