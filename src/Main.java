import java.util.Random;

public class Main {
    static Random random = new Random();
    static String allowedCharacters = "!@#$%^&*()_+-=[]{}|;:,.<>?";
    static String password = "";
    public static void main(String[] args) {
        if (args.length < 2  || args[0].equalsIgnoreCase("help")) {
            System.out.println("Пример: java -jar GeneratePassword.jar 20 i");
            System.out.println("Первый аргумент это длина пароля. В примере выше - 20");
            System.out.println("Второй аргументт это тип пароля:");
            System.out.println("    i - только числа");
            System.out.println("    a - только буквы");
            System.out.println("    ai - числа и буквы");
            System.out.println("    is - числа и символы");
            System.out.println("    as - буквы и символы");
            System.out.println("    ais - буквы, числа и символы");
            System.exit(0);
        }
        switch (args[1]) {
            case "i":
                for (int i = 0; i < Integer.parseInt(args[0]); i++)
                    password += generateIntToString();
                break;
            case "a":
                for (int i = 0; i < Integer.parseInt(args[0]); i++)
                    password += generateChar();
                break;
            case "ai":
                for (int i = 0; i < Integer.parseInt(args[0]) / 2; i++) {
                    password += generateIntToString();
                    password += generateChar();
                }
                break;
            case "is":
                for (int i = 0; i < Integer.parseInt(args[0]) / 2; i++) {
                    password += generateIntToString();
                    password += generateSymbol();
                }
                break;
            case "as":
                for (int i = 0; i < Integer.parseInt(args[0]) / 2; i++) {
                    password += generateChar();
                    password += generateSymbol();
                }
                break;
            case "ais":
                while (true) {
                    if (password.length() != Integer.parseInt(args[0])) password += generateChar();
                    if (password.length() != Integer.parseInt(args[0])) password += generateIntToString();
                    if (password.length() != Integer.parseInt(args[0])) password += generateSymbol();
                    if (password.length() == Integer.parseInt(args[0])) break;
                }
                break;
            default:
                System.out.println("Указан неверный параметр!");
                System.exit(0);
        }
        System.out.println("Пароль: " + password);
    }
    public static char generateChar() {
        boolean isUpperCase = random.nextBoolean(); // Генерируем случайное значение true или false
        char randomLetter;
        if (isUpperCase) {
            randomLetter = (char) (random.nextInt(26) + 'A'); // Генерируем случайную букву в верхнем регистре
        } else {
            randomLetter = (char) (random.nextInt(26) + 'a'); // Генерируем случайную букву в нижнем регистре
        }
        return randomLetter;
    }

    public static String generateIntToString() {
        return String.valueOf(random.nextInt(10));
    }

    public static char generateSymbol() {
        return allowedCharacters.charAt(random.nextInt(allowedCharacters.length()));
    }
}