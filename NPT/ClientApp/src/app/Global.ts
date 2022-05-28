
export class GlobalFunctions {
    public static IsNullorEmpty(input: string) {
        return input === undefined || input === null || input.match(/^ *$/) !== null;
    }

}