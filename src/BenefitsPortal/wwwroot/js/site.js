// Write your Javascript code.
//These two functions work with the PTOaccrual view and controller to accrue the employees total PTO after some is used
//The function below calls this function and passes the new EmployeeArray with the new PTOTotal value to it. 
//Then it posts this new array as a promise to the AccruePTO method on the Hr controller. 
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
//this function listens for a click on the PTO button, grabs the values of entered for used PTO and puts them into an array. 
//then it creates a new array, foreaches through the used PTO array pushing those values along with the values for the 
//employee Id, PTO accrual rate, and the current PTO total into an object and then puts those objects into the array.
//Then, it foreaches through the new EmployeeArray of objects and does the math to get the new value of the PTO total.
//Finally, it calls the function above sending the new EmployeeArray as the  parameter.
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
