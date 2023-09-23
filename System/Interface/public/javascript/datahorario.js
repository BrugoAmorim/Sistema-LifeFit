
export const modelohorarioBr = (data) => {

    const newDt = new Date(data);

    let dia = newDt.getDate();
    dia = dia < 10 ? '0' + dia : dia;

    let mes = newDt.getMonth() + 1;
    mes = mes < 10 ? '0' + mes : mes;

    return dia + '/' + mes + '/' + newDt.getFullYear();
}