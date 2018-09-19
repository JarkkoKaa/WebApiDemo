/// <binding BeforeBuild='clean' AfterBuild='default' />
var gulp = require('gulp');
var del = require('del');

var paths = {
    scripts: ['Source/**/*.js', 'Source/**/*.ts', 'Source/**/*.map'],
};

gulp.task('clean', function () {
    return del(['wwwroot/js/**/*']);
});

gulp.task('default', function () {
    gulp.src(paths.scripts).pipe(gulp.dest('wwwroot/js'));
});