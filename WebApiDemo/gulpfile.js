/// <binding BeforeBuild='clean' AfterBuild='default' />
var gulp = require('gulp');
var del = require('del');

var paths = {
    scripts: ['Source/**/*.js', 'Source/**/*.ts', 'Source/**/*.map'],
    styles: ['Source/**/*.css'],
};

gulp.task('clean', function () {
    return del(['wwwroot/js/**/*']);
});
gulp.task('clean', function () {
    return del(['wwwroot/css/**/*']);
});

gulp.task('default', function () {
    gulp.src(paths.scripts).pipe(gulp.dest('wwwroot/js'));
    gulp.src(paths.styles).pipe(gulp.dest('wwwroot/css'));
});