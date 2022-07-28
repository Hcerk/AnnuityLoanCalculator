


window.addEventListener('load', () => {
    var listInput = [loan_amount, loan_term, rate_year, payment_step] = [
        document.getElementById('frm_loan_amount'),
        document.getElementById('frm_loan_term'),
        document.getElementById('frm_rate_year'),
        document.getElementById('frm_payment_step')
    ];

    var listCheckbox = [inMonts, inDays] = [
        document.getElementById('checkMonths'),
        document.getElementById('checkDays')
    ];

    var paymentStepParent = document.getElementById('payment_step_parent');

    var listInputLabel = [...document.getElementsByTagName('label')];

    function checkValidValue() {
        listInput.map(input => {
            if (Number(input.value) > 0) {
                if (!input.classList.contains('is-valid'))
                    input.classList.add('is-valid')
            } else {
                if (!input.classList.contains('is-invalid'))
                    input.classList.add('is-invalid')
            }
        })
    }

    if (loan_amount && loan_term && rate_year)
        listInput.map(input => input.addEventListener('change', () => checkValidValue()))

    function checkSelect() {
        if (inDays.checked) {
            if (paymentStepParent.getAttribute('hidden') == '')
                paymentStepParent.removeAttribute('hidden');
        }
        else if (inMonts.checked)
            if (!paymentStepParent.getAttribute('hidden')) {
                paymentStepParent.setAttribute('hidden', '');
                payment_step.value = 1;
            }
    }

    listCheckbox.map(item => {
        if (item)
            item.addEventListener('change', () => {
                if (listInputLabel.length >= 1)
                    listInputLabel.map(element => {
                        if (element)
                            if (element.classList.length == 0) {
                                if (element.getAttribute('for') == 'frm_loan_term')
                                    element.textContent = inMonts.checked ? 'Срок займа (в месяцах)*' : "Срок займа (в днях)*";
                                else if (element.getAttribute('for') == 'frm_rate_year')
                                    element.textContent = inMonts.checked ? 'Ставка (в год)**' : "Ставка (в днях)*";
                            }
                    });

                checkSelect();
            });
    });

    checkSelect();
    checkValidValue();
});