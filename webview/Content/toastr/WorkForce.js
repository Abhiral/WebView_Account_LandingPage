﻿$(function () {
    WorkForce.init();
    $('#content-data-table tbody tr').attr('contenteditable', 'true');
    $('#content-data-table tbody td').attr('contenteditable', 'false');
    $('#content-data-table').dataTable({
        "lengthMenu": [[50, 75, 100, -1], [50, 75, 100, "All"]]
    });
    $('#content-data-table tbody tr').on('keydown', function (e) {
        switch (e.which) {
            case 37: // left
                break;

            case 38: // up
                $(e.target).prev().focus();
                break;

            case 39: // right
                break;

            case 40: // down
                $(e.target).next().focus()
                break;
            case 13: //enter
                var buttons = $(e.target).find('a,button');
                var firstButton = buttons.eq(0);
                firstButton.focus();
                firstButton.addClass('current-focused-button');
                break;
            default: return; // exit this handler for other keys
        }
        e.preventDefault();
    });

    $('#content-data-table tbody tr').on('focus', function (e) {
        $(e.target).css('background', '#ffdcdc');
    })
    $('#content-data-table tbody tr').on('blur', function (e) {
        $(e.target).css('background', '#f7f7f7');
    })

    //another data-table

    $('#content-data-table-report tbody tr').attr('contenteditable', 'true');
    $('#content-data-table-report tbody td').attr('contenteditable', 'false');

    $('#content-data-table-report tbody tr').on('keydown', function (e) {
        switch (e.which) {
            case 37: // left
                break;

            case 38: // up
                $(e.target).prev().focus();
                break;

            case 39: // right
                break;

            case 40: // down
                $(e.target).next().focus()
                break;
            case 13: //enter
                var buttons = $(e.target).find('a,button');
                var firstButton = buttons.eq(0);
                firstButton.focus();
                firstButton.addClass('current-focused-button');
                break;
            default: return; // exit this handler for other keys
        }
        e.preventDefault();
    });
    $('#content-data-table-report tbody tr').on('focus', function (e) {
        $(e.target).css('background', '#ffdcdc');
    })
    $('#content-data-table-report tbody tr').on('blur', function (e) {
        $(e.target).css('background', '#f7f7f7');
    })
    $('body').on('keydown', 'input, select,button', function (e) {
        var self = $(this)
          , form = self.parents('form:eq(0)')
          , focusable
          , next
          , prev
        ;
        if (e.shiftKey) {
            if (e.keyCode == 13) {
                focusable = form.find('input,a,select,button,textarea').filter(':visible');
                prev = focusable.eq(focusable.index(this) - 1);

                if (prev.length) {
                    prev.focus();
                }// else {
                //    form.submit();
                //}
            }
        }
        else if (e.keyCode == 13) {
            focusable = form.find('input,a,select,button,textarea').filter(':visible');
            next = focusable.eq(focusable.index(this) + 1);
            if (next.length) {
                next.focus();
            } else {
                if ($(e.target).attr('data-btn-type') == 'save') {
                    if (confirm("Are you sure to save ?")) {
                        form.submit();
                    }
                }
                else {
                    form.submit();
                }
            }
            return false;
        }
    });

});
var WorkForce = {
    init: function () {
        this.loader.init();
    },
    loader: {
        init: function () {
            $(window).bind('load', function () {
                WorkForce.loader.hide(500);
            });
        },
        show: function (t) {
            t = t ? t : 500;
            $('.loader-wrap').fadeIn(t);
        },
        hide: function (t) {
            t = t ? t : 500;
            $('.loader-wrap').fadeOut(t);
        }
    }
}

var NumberConverter = {
    NumberToWords: function (n) {
        var nums = n.toString().split('.')
        var whole = this.convertNumberToWords(nums[0])
        if (nums.length == 2) {
            var fraction = this.convertNumberToWords(nums[1])
            if (fraction != '') {
                return whole + 'and ' + fraction;
            }
            else {
                return whole;
            }
        } else {
            return whole;
        }
    },
    convertNumberToWords: function (amount) {
        var words = new Array();
        words[0] = '';
        words[1] = 'One';
        words[2] = 'Two';
        words[3] = 'Three';
        words[4] = 'Four';
        words[5] = 'Five';
        words[6] = 'Six';
        words[7] = 'Seven';
        words[8] = 'Eight';
        words[9] = 'Nine';
        words[10] = 'Ten';
        words[11] = 'Eleven';
        words[12] = 'Twelve';
        words[13] = 'Thirteen';
        words[14] = 'Fourteen';
        words[15] = 'Fifteen';
        words[16] = 'Sixteen';
        words[17] = 'Seventeen';
        words[18] = 'Eighteen';
        words[19] = 'Nineteen';
        words[20] = 'Twenty';
        words[30] = 'Thirty';
        words[40] = 'Forty';
        words[50] = 'Fifty';
        words[60] = 'Sixty';
        words[70] = 'Seventy';
        words[80] = 'Eighty';
        words[90] = 'Ninety';
        amount = amount.toString();
        var atemp = amount.split(".");
        var number = atemp[0].split(",").join("");
        var n_length = number.length;
        var words_string = "";
        if (n_length <= 9) {
            var n_array = new Array(0, 0, 0, 0, 0, 0, 0, 0, 0);
            var received_n_array = new Array();
            for (var i = 0; i < n_length; i++) {
                received_n_array[i] = number.substr(i, 1);
            }
            for (var i = 9 - n_length, j = 0; i < 9; i++, j++) {
                n_array[i] = received_n_array[j];
            }
            for (var i = 0, j = 1; i < 9; i++, j++) {
                if (i == 0 || i == 2 || i == 4 || i == 7) {
                    if (n_array[i] == 1) {
                        n_array[j] = 10 + parseInt(n_array[j]);
                        n_array[i] = 0;
                    }
                }
            }
            value = "";
            for (var i = 0; i < 9; i++) {
                if (i == 0 || i == 2 || i == 4 || i == 7) {
                    value = n_array[i] * 10;
                } else {
                    value = n_array[i];
                }
                if (value != 0) {
                    words_string += words[value] + " ";
                }
                if ((i == 1 && value != 0) || (i == 0 && value != 0 && n_array[i + 1] == 0)) {
                    words_string += "Crores ";
                }
                if ((i == 3 && value != 0) || (i == 2 && value != 0 && n_array[i + 1] == 0)) {
                    words_string += "Lakhs ";
                }
                if ((i == 5 && value != 0) || (i == 4 && value != 0 && n_array[i + 1] == 0)) {
                    words_string += "Thousand ";
                }
                if (i == 6 && value != 0 && (n_array[i + 1] != 0 && n_array[i + 2] != 0)) {
                    words_string += "Hundred and ";
                } else if (i == 6 && value != 0) {
                    words_string += "Hundred ";
                }
            }
            words_string = words_string.split("  ").join(" ");
        }
        return words_string + ' Only';
    }
}
var CustomNavigation = {
    ReloadIfBack: function () {
        if (performance.navigation.type == 2) {
            location.reload(true);
        }
    }
}