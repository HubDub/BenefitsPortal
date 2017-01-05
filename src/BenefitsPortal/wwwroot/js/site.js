// Write your Javascript code.
function postResults(EmployeeArray) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            url: '/Hr/AccruePto',
            method: "POST",
            contentType: "application/json",
            data: JSON.stringify(EmployeeArray)

        }).done(function (data) {
            resolve(data)
        })
        .error(function (err) {
            reject(err)
        })
    })
}

$("#accruePto").on("click", function () {
    var EmployeeUsedPto = $(".UsedPto").toArray();
    var EmployeeArray = [];
    EmployeeUsedPto.forEach(function (IndEmployeeUsedPto) {
        EmployeeArray.push({
            PtoUsedLast : IndEmployeeUsedPto.value,
            EmployeeId: $(IndEmployeeUsedPto).parent().attr("id"),
            PtoRate: $(IndEmployeeUsedPto).parent().parent().siblings(".PtoRate").attr("id"),
            PtoTotal: $(IndEmployeeUsedPto).parent().parent().siblings(".PtoTotal").attr("id")
        })
    })

    EmployeeArray.forEach(function (IndEmployeePair) {
        IndEmployeePair.PtoTotal = parseFloat(IndEmployeePair.PtoTotal) + parseFloat(IndEmployeePair.PtoRate) - parseFloat(IndEmployeePair.PtoUsedLast)
        IndEmployeePair.PtoTotal = IndEmployeePair.PtoTotal.toFixed(2);
    })
    console.log(EmployeeArray);
    postResults(EmployeeArray).then(function () {
       window.location.href = '/hr/Dashboard'
    });
})
