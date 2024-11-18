// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace SmartComponents.LocalEmbeddings.Test;

internal static class TestData
{
    /*
      Notes on comparing the numerical values with Python
      ===================================================

      You can generate output from Python using something like this:
     
        from sentence_transformers import SentenceTransformer
        from transformers import AutoTokenizer

        sentence_to_use = "This is a LOVELY sentence"

        # Show the raw tokens
        tokenizer = AutoTokenizer.from_pretrained('TaylorAI/bge-micro-v2')
        encoded_input = tokenizer(sentence_to_use, padding=True, truncation=True, return_tensors='pt')
        print(encoded_input)

        # Show the embedding
        model = SentenceTransformer("TaylorAI/bge-micro-v2")
        embedded = model.encode(sentence_to_use)
        print(embedded)

      However, the numbers will be different from .NET's output for two reasons:

      [1] .NET is using the *quantized* version of the model, and Python here is not. The easiest way to
          make this consistent it to change .NET to use the non-quantized model by setting <LocalEmbeddingsModelUrl>
          to https://huggingface.co/TaylorAI/bge-micro-v2/resolve/main/onnx/model.onnx

      [2] Python uses mean pooling, but .NET uses sum pooling (because it's faster to compute, and the magnitude
          of the output vector is irrelevant for cosine similarity). You could amend the .NET logic in LocalEmbeddings's
          PoolSum() to divide the output by the number of input tokens, then the numbers should match Python's output.
    */

    // These were generated by running against https://huggingface.co/TaylorAI/bge-micro-v2/resolve/main/onnx/model_quantized.onnx
    // after verifying that it agrees with output from running the model in Python. This is based on a case-insensitive tokenizer.
    public static IReadOnlyDictionary<string, float[]> BgeMicroV2Samples = new Dictionary<string, float[]>()
    {
        [""] = [-0.625831f, 0.155055f, 0.558915f, -0.345807f, 0.453506f, 0.670642f, 1.353459f, 0.535430f, -0.497597f, -1.035092f, 0.388924f, 0.120007f, 0.100918f, 0.304227f, 0.497151f, 0.050672f, 0.477042f, 0.251804f, -0.707558f, 0.010893f, -0.385528f, -0.481558f, 0.001833f, -0.378607f, -0.067808f, -0.033740f, 0.153730f, -0.440248f, -0.574364f, -1.576508f, 0.046614f, 0.230679f, 0.449580f, -0.071599f, 0.459853f, 0.572514f, -0.209392f, 0.029670f, -1.057437f, -0.126790f, 0.337262f, 0.047791f, -0.365429f, -0.388226f, 0.476654f, -0.090512f, -0.101000f, 0.107779f, 1.090923f, 0.119435f, 0.158029f, -0.744611f, -0.079113f, 0.160615f, 0.430450f, 0.515518f, 0.437929f, 0.383551f, 0.364640f, 0.462803f, 0.265744f, 0.464187f, -2.235362f, 0.434478f, 0.087192f, 0.646401f, 0.064740f, 0.081673f, 0.075200f, 0.129951f, 0.420703f, -0.092798f, 0.471699f, 0.855954f, 0.073041f, 0.045894f, -0.206452f, -0.395163f, -0.895448f, -0.086415f, 1.023677f, -0.529112f, 0.376618f, -0.419613f, -0.183838f, -0.059592f, 0.611565f, -0.481632f, 0.008194f, 0.376784f, 0.157328f, -0.277426f, 0.129968f, -0.260873f, -0.522073f, -0.991430f, 0.156824f, -0.902192f, 0.474078f, 6.352257f, 0.049458f, -0.064975f, 1.180263f, -0.421582f, -0.283772f, -0.524932f, 0.392924f, 0.179826f, -0.263328f, 0.039223f, 0.062963f, -0.017470f, 0.871653f, -0.031206f, 0.069927f, 0.684320f, 0.348084f, 0.769424f, 0.275146f, -0.474221f, -0.033225f, -0.155902f, -0.130118f, -0.028688f, 0.615919f, 0.120316f, 0.236223f, 2.135317f, -0.159753f, 0.786917f, -0.200101f, 0.175355f, -0.119659f, 0.217075f, -0.006278f, -0.084970f, 0.298809f, 0.296465f, 0.195772f, -0.051328f, -0.442497f, -0.373497f, -0.283581f, -1.426156f, -0.160707f, 0.642861f, -0.051583f, -0.540615f, -0.476198f, 0.494720f, 0.110050f, 0.338333f, -0.008154f, 0.637670f, 0.049072f, 0.091311f, 0.493936f, 0.263872f, 0.218710f, 0.830819f, -0.318485f, 0.374847f, -0.001470f, 1.116166f, -0.353380f, -1.799527f, 0.058470f, -0.221332f, 0.121524f, -0.215788f, -0.159910f, 0.343764f, -0.355452f, 0.885149f, 1.142439f, -0.229453f, -0.429182f, 0.089962f, -0.885675f, 0.125424f, 0.676300f, -0.017619f, -0.202007f, 0.143235f, -0.011387f, -0.424121f, -0.483721f, -0.472294f, -0.453083f, 0.818202f, -0.443922f, 1.320221f, -0.069503f, -0.194699f, -0.489212f, -0.407713f, -0.819044f, -0.517619f, -0.394285f, -0.450247f, 0.121891f, -0.033965f, -0.724713f, -0.213848f, 1.268813f, 0.339804f, 0.201022f, -0.092834f, -0.043623f, -0.065381f, 0.155367f, -0.622483f, 1.068389f, 0.276658f, -0.649747f, 0.262230f, -0.280763f, 1.129846f, 0.346480f, -0.402363f, 0.311287f, -0.130352f, 0.101435f, -4.578176f, -0.235463f, -0.385231f, -0.393878f, -0.567596f, -0.503319f, -0.006638f, -0.185313f, -0.110562f, 0.335295f, 0.046974f, 0.052948f, -0.331633f, -0.176655f, -0.047417f, 0.213161f, 0.102618f, -0.170969f, 0.306331f, -0.242249f, -0.294136f, 0.613845f, -0.063209f, -0.599489f, 0.080052f, -0.895891f, 2.137562f, 0.687289f, -0.049095f, -0.434518f, -0.017046f, 0.265215f, -0.101382f, -0.996741f, 0.086729f, 0.224853f, 0.611473f, -0.232071f, -0.279030f, 0.063996f, 0.291204f, 0.255982f, -0.139628f, -1.100282f, -0.456943f, -0.834920f, -0.422311f, 0.085375f, 0.354236f, -0.545049f, 0.631448f, 0.431534f, 0.779349f, 0.064725f, -0.125173f, -0.568911f, 0.283943f, 0.043519f, -0.402668f, -0.544861f, 0.249842f, -0.111160f, 0.575496f, -0.261585f, 0.475061f, 0.188103f, 0.034473f, 0.014510f, 0.423558f, 0.175720f, -0.153257f, -0.204211f, -0.778163f, -0.579669f, 0.729039f, 0.201684f, 0.823770f, -0.451049f, -0.327495f, -0.582099f, -0.019611f, -0.609034f, -0.112761f, -0.138627f, -0.137433f, 0.286676f, 0.098895f, 0.149362f, 0.066110f, -0.251857f, -0.181583f, 0.553653f, -0.204807f, -0.086337f, 0.371215f, -0.054119f, -4.452644f, -0.067481f, -0.771928f, -0.957880f, -0.003266f, 0.554022f, -0.202467f, 0.681602f, 0.184327f, 0.797986f, 0.297380f, 1.129318f, -0.126418f, 0.088678f, -0.093825f, 0.643678f, 1.238467f, -0.173383f, 0.377479f, -0.270901f, 0.006463f, 0.670893f, 2.216036f, -0.972156f, 0.150536f, 0.845408f, -0.245047f, -0.379351f, -0.305841f, -0.574906f, 0.662380f, 0.034491f, 0.691151f, -0.330828f, 0.026344f, 0.242625f, -0.559037f, 0.131643f, -0.119785f, 0.075967f, -0.956664f, 0.155039f, -0.253771f, -0.168382f, 0.359666f, -0.064260f, -0.423074f, 0.049696f, -0.128487f, 0.423723f, -0.143558f, 0.149678f, 0.193622f, 0.187209f, 0.207225f, 0.158563f, -1.040801f, -0.189590f, 0.613414f, -0.698165f, -0.543536f, -0.807430f, -0.184180f, 0.419226f, 0.134133f,],
        ["a"] = [-0.831680f, 0.603627f, 0.788481f, -0.191275f, -0.532971f, 1.076671f, 1.741283f, 1.007926f, 0.016767f, -0.629583f, -0.228883f, -0.017227f, -0.133186f, 0.664594f, 1.021871f, 0.549065f, 0.411423f, 0.375974f, -0.006092f, 0.453953f, 0.066072f, -0.650929f, -0.324474f, -0.746138f, 0.262774f, 0.577068f, -0.060540f, -1.098679f, -0.778860f, -2.835062f, -0.945884f, 0.453386f, 1.865392f, 0.074367f, 0.073601f, 0.551056f, -0.330444f, 0.297235f, -0.951333f, 0.217172f, 0.759891f, -0.258929f, -0.996585f, -0.981370f, 0.329015f, -0.154479f, 0.116079f, 0.245735f, 0.713007f, 0.044773f, -0.137465f, -1.117539f, -0.450207f, -0.338791f, 0.034231f, 0.730772f, 0.550284f, 0.413978f, 0.431736f, 0.397622f, 0.386093f, 0.941612f, -3.191797f, 1.655800f, 0.587335f, 0.621376f, 0.243581f, 0.079677f, 0.203665f, -0.269906f, 0.235098f, -0.185306f, 1.176144f, 1.116924f, -0.193473f, -0.538607f, -0.404478f, -0.851856f, 0.061064f, -0.105766f, 0.280270f, -0.483967f, 0.195675f, 0.278763f, -0.058082f, -0.189314f, 0.838745f, -0.737667f, 0.113131f, 0.335625f, -0.809665f, -0.289607f, 0.238875f, -0.280212f, -0.137046f, -1.099217f, -0.710771f, -1.621964f, 0.830114f, 7.006760f, -0.403989f, 0.176987f, 2.252748f, -0.993782f, -0.240899f, -0.544215f, 0.241562f, -0.395174f, -0.395824f, 0.677649f, 0.527825f, -0.332169f, 0.341785f, -0.664347f, -0.083292f, 0.283173f, 0.497950f, 0.891829f, 0.876983f, -0.377790f, -0.348497f, 0.031742f, -0.406381f, -0.523428f, 0.574942f, 0.543573f, 1.191450f, 2.845051f, 0.122795f, 2.183357f, 0.139323f, 0.448131f, -0.101807f, 0.444443f, 0.014782f, -0.449277f, 0.358483f, -0.178010f, 0.092136f, 0.825148f, -0.804406f, -0.119564f, 0.445785f, -2.082144f, -0.779192f, 1.422613f, 0.353161f, -0.273834f, -0.207792f, 0.787077f, -0.020280f, 0.382736f, -0.152912f, 0.147030f, 0.154232f, 0.176479f, 0.589349f, 0.796093f, 0.231547f, 0.745861f, -0.679889f, 0.077039f, -0.659599f, 0.858857f, 0.083663f, -2.875364f, 0.439704f, -0.598587f, 0.155106f, -0.240417f, 0.060337f, 0.484367f, -0.682373f, 1.177289f, 0.806370f, 0.024556f, -0.569386f, 0.185476f, -0.801343f, 0.144993f, 1.426783f, -0.298064f, -0.248616f, 0.667066f, 0.589431f, 0.030024f, -0.715404f, -0.758668f, -0.166374f, 1.034235f, -1.104372f, 2.507267f, -0.760792f, -0.143590f, -1.147567f, -0.473081f, -0.683012f, -1.019555f, -0.572183f, -0.148330f, 0.609495f, 0.279451f, -0.742659f, 0.679671f, 1.960252f, 0.398476f, 0.023531f, 0.644604f, -0.591184f, 0.095733f, 0.041484f, -0.418973f, 1.166928f, -0.162537f, -0.895982f, -0.405531f, -0.331250f, 1.378945f, -0.153003f, -0.854492f, 0.324890f, -0.961923f, 0.035645f, -6.092313f, 0.141105f, -0.180176f, -0.754733f, 0.630893f, -0.653455f, 0.185607f, -0.545971f, -0.502037f, 0.023045f, 0.669565f, -0.453536f, -0.544331f, -0.184359f, -0.013998f, 1.154227f, 0.207995f, -0.006722f, 0.486489f, -0.059359f, -0.650376f, 1.389036f, 0.401607f, -0.434406f, -0.724270f, -0.774693f, 3.800382f, 1.126456f, 0.145161f, -0.227989f, 0.528248f, -0.575245f, 0.047895f, -1.820414f, -0.358065f, 0.370967f, 0.713910f, 0.264951f, -0.640915f, -0.069187f, 1.309982f, 0.949345f, -0.095168f, -1.168740f, -0.040864f, -1.178570f, -0.378995f, -0.338943f, 0.009812f, -0.479752f, 0.714839f, -0.480798f, 0.563769f, 0.241366f, -0.001874f, -0.516932f, -0.577180f, -0.366875f, -0.832407f, 0.621232f, 0.118742f, 0.306625f, 0.809614f, -1.291610f, 0.939590f, 0.222288f, 0.373312f, -0.450812f, 0.541336f, -0.668788f, -0.185721f, 0.118744f, -0.507165f, -1.893969f, 0.744953f, 0.202348f, 0.295344f, -0.453918f, -0.976544f, -0.550341f, 0.274937f, -1.773964f, -0.243759f, -0.040816f, -0.071608f, 0.471885f, 0.369180f, 0.457516f, 0.304376f, -0.161180f, -0.176279f, 1.026931f, -0.382625f, -0.403128f, 0.361176f, -0.077700f, -6.823195f, -0.187771f, -0.544689f, -1.312374f, 0.336099f, 0.604669f, 0.025182f, 1.592153f, -1.137499f, 0.925843f, 0.256755f, 0.680972f, -0.083482f, 0.596103f, 0.381615f, -0.078475f, 1.220549f, -0.310000f, 0.765178f, -0.925550f, 0.018712f, 1.274906f, 3.021240f, -1.723997f, 0.732102f, 1.091149f, -0.478558f, -0.663096f, -0.743429f, -0.992924f, 1.135337f, -0.016692f, 1.044096f, -1.010108f, 0.459331f, 0.386086f, -0.761605f, 0.807349f, -0.104684f, 0.026507f, -1.566684f, 0.071676f, 0.366707f, -0.054351f, 1.404886f, -0.493350f, -0.620872f, -0.946818f, -0.164684f, -0.033043f, 0.416112f, 0.762012f, -0.129471f, 0.388136f, -0.010177f, -0.005508f, -1.638415f, 0.121520f, 0.869161f, -1.275931f, -0.549488f, -1.031836f, 0.866580f, 0.321298f, 1.344850f,],
        ["Hello, world!"] = [-1.942821f, -0.644943f, 2.050733f, -1.147022f, 1.326033f, -0.377670f, 1.668012f, 3.331283f, -0.163851f, -1.017537f, 1.492448f, -1.887636f, 1.572382f, 1.844074f, 0.270980f, -0.985722f, 0.538103f, -1.608945f, -4.765300f, 0.192772f, 1.933463f, -0.661791f, -1.112341f, -1.471296f, 1.167389f, 0.451102f, -0.877302f, -0.739824f, -0.702449f, -6.370782f, -2.148516f, 0.173058f, 1.188590f, 1.808193f, -0.523421f, -1.355901f, 0.289651f, -0.719997f, -2.958027f, 0.545801f, 0.955431f, 0.170658f, -0.277479f, -0.524523f, 0.654727f, -1.382824f, -0.994370f, 0.756707f, -0.900180f, -0.669709f, 0.650382f, 0.283290f, -1.321328f, 1.207978f, 2.201842f, 1.535419f, 2.567736f, -0.215998f, 1.960779f, 0.097080f, 1.914014f, 0.154570f, -7.368906f, 3.114351f, -1.087273f, 0.993719f, 1.522824f, 1.374095f, -0.524154f, 1.234288f, 1.380446f, 0.420392f, 1.294687f, 1.786235f, 0.295113f, 0.824021f, 0.621033f, -1.600565f, -0.516195f, -0.820370f, 2.105738f, -2.088471f, -0.613615f, -0.240313f, -2.182523f, 0.404853f, 0.877943f, 1.777146f, -0.866802f, 1.052089f, -3.072018f, -1.864419f, 2.456527f, 0.714283f, -3.212345f, -1.610232f, 0.738277f, 0.126018f, -1.155795f, 6.624237f, -2.091774f, 1.082080f, 4.370533f, -2.110845f, 0.404366f, 0.598053f, -0.803794f, 0.055029f, -0.996196f, -0.512675f, 0.364016f, -0.862033f, 2.488584f, -0.970240f, 0.780385f, -0.760262f, 1.456736f, 0.960813f, 0.679180f, -2.864436f, 0.493243f, 1.323429f, 0.341978f, -0.367388f, 2.720391f, -0.834089f, 2.790701f, 3.682444f, 0.749193f, 3.397099f, 1.498716f, 3.249668f, -1.116322f, 0.101035f, 0.315128f, 0.279974f, 1.306708f, -0.518717f, 2.092056f, -1.319748f, -0.540784f, -1.054921f, -1.491019f, -5.274900f, 0.510089f, 0.821674f, -0.239115f, -1.573340f, -0.373907f, 1.008762f, -0.150740f, 2.257746f, -1.099817f, 0.792318f, 1.656615f, 1.357915f, 2.613234f, 2.515351f, -0.015683f, 2.123651f, -0.203407f, -0.489359f, 0.226673f, 2.104174f, 0.353846f, -6.118645f, -1.066198f, -1.215068f, -1.310014f, 0.485777f, -0.533114f, -0.261356f, -2.081440f, 0.995006f, 4.334429f, 0.503220f, 0.529471f, 2.504006f, -1.089352f, -0.802394f, 0.313503f, -0.669756f, -1.222557f, -0.559234f, 0.504486f, -2.065272f, 0.017636f, 0.346699f, 0.477127f, 0.123328f, 0.502432f, 1.792653f, -1.274606f, -0.550269f, -0.442369f, -0.371698f, 0.212762f, -2.536860f, 1.286417f, -1.735270f, 1.799288f, 0.034139f, -0.977611f, 0.268642f, 4.266644f, 1.099512f, 1.842613f, -0.636501f, 0.489606f, 1.121590f, -1.327511f, -1.918077f, 5.528311f, 0.720288f, -0.779720f, -0.548511f, -1.600978f, 1.096221f, -0.311152f, 0.535030f, 0.651485f, -2.845026f, -2.992882f, -9.675945f, 0.856854f, -0.583413f, -3.024846f, -0.504115f, -0.619250f, 0.595699f, -0.338661f, 2.718726f, 1.173173f, 4.124810f, -0.242826f, 1.417548f, -0.078211f, 0.584561f, -0.277498f, -0.750334f, -0.802415f, 0.429027f, -1.007099f, 0.387666f, 2.167734f, -0.434221f, -3.423383f, -0.471743f, -1.602719f, 4.407694f, 5.849043f, 1.117155f, -1.633057f, 1.984442f, 0.648976f, 0.979269f, -5.706013f, 0.408669f, 0.613455f, 1.725450f, -2.330238f, -2.450666f, -0.035778f, -1.121334f, 1.005766f, -0.252709f, -3.312536f, -0.294914f, -3.157084f, -2.766318f, -0.926285f, -0.281839f, -0.569200f, 1.308521f, -1.158822f, 0.406854f, 0.820397f, -1.478008f, -2.663704f, -0.015523f, -0.581678f, -1.274435f, 2.263239f, -0.036401f, -0.393973f, 0.074108f, 0.500814f, -0.603065f, 2.135709f, -0.736304f, 0.288940f, 3.529635f, -1.310570f, -1.966083f, 0.041844f, 0.895024f, -1.407917f, 2.317519f, 0.096821f, 1.066753f, -0.019094f, -3.223608f, -1.213171f, -0.031015f, -2.112220f, 2.309745f, 0.504589f, -0.173881f, 1.766974f, 1.351321f, -0.214933f, 0.776123f, -1.286662f, -0.897710f, 0.365345f, -0.434736f, -1.574831f, 2.237262f, -2.001068f, -10.736120f, 0.505209f, -0.200135f, 0.284122f, -0.146415f, 2.563190f, 2.315803f, 2.456761f, -1.528654f, -0.162609f, 0.372899f, 1.341291f, 1.896773f, 1.701421f, 2.019072f, 1.507868f, 0.444863f, 0.665171f, 1.964517f, 0.574471f, -0.282570f, 1.962546f, 6.924829f, -1.502111f, 2.006687f, 2.118441f, -1.021825f, 0.111075f, 0.520472f, -2.068831f, -0.872655f, -0.971733f, 0.052198f, -2.018909f, 1.299568f, -1.045834f, -1.000474f, 1.174089f, 0.679285f, -0.585938f, -3.924797f, 1.092637f, 0.851275f, 1.133868f, 1.561536f, -2.005651f, -1.712920f, -1.058635f, -0.573933f, 1.637167f, -0.998480f, -0.563631f, -0.578920f, 1.060209f, -0.950077f, 0.923947f, -0.148061f, -1.776332f, -0.323813f, -2.296682f, 0.559869f, -1.672897f, 1.176520f, 0.623067f, 1.012148f,],
        ["Guess what - this is another string."] = [-5.630024f, -3.431213f, 0.170780f, -3.994304f, -0.362643f, -3.178852f, 1.401501f, 2.585698f, 3.306523f, -1.508175f, 2.412734f, -1.249512f, -1.197825f, 1.922632f, -0.427373f, -0.034671f, -0.262196f, -1.038823f, -5.592237f, 1.380834f, 6.224315f, 3.791982f, -1.222454f, -2.417317f, 0.777557f, 5.154459f, -0.027709f, -4.295518f, -1.149132f, -9.033001f, -0.787683f, -3.506922f, -1.446719f, -1.488326f, 2.668259f, -2.947230f, -2.667103f, 1.857937f, -2.782712f, 3.585197f, 1.610448f, 0.056073f, -3.672989f, -0.939413f, -2.448153f, -4.210611f, -2.219384f, 0.149678f, -0.792609f, -1.857425f, -1.616561f, -0.868635f, -0.924433f, -2.609556f, 0.988980f, 3.386906f, 2.102345f, 5.292688f, 2.171971f, 2.675766f, 5.544689f, 2.135899f, -5.970110f, 5.531165f, 3.975664f, 1.577903f, 1.142362f, -2.574682f, 0.726668f, 3.052425f, 4.584161f, 0.901620f, -0.524285f, 5.418046f, 0.502072f, -0.144139f, 0.744446f, -3.553821f, 0.098536f, 3.365908f, -2.394819f, -4.943295f, -0.285048f, 0.459723f, -2.654014f, 0.683459f, -3.766167f, 1.460074f, 2.489877f, 0.936275f, -1.713214f, -3.657217f, 1.168620f, 0.812565f, -6.036767f, -1.198757f, -0.471516f, 2.033722f, -0.084265f, 10.047260f, -5.042998f, -1.283549f, 5.291524f, -3.546751f, 1.975522f, -1.286833f, -0.589838f, -2.181879f, -2.134459f, -2.838028f, 0.881749f, -1.253147f, -0.655637f, -2.175142f, -0.170572f, 4.077866f, 3.181829f, 0.035850f, -2.700065f, 1.736460f, 0.424897f, -1.760648f, -1.458440f, -2.245273f, 2.346013f, -1.077651f, 2.656337f, 3.885288f, 2.471439f, 4.498833f, 6.607026f, -4.260117f, -2.380143f, 0.156767f, -0.175531f, 0.248325f, 1.947327f, 0.489477f, 2.405420f, -2.433991f, -1.023293f, -6.648031f, -4.175252f, -3.498133f, -5.246711f, 4.460063f, -3.375889f, -2.558470f, 0.654307f, 0.747486f, -2.040398f, 0.027360f, -0.556156f, -2.902026f, 0.744130f, -0.214754f, 3.354908f, -0.888113f, -1.139650f, 1.231038f, -0.099482f, -1.528315f, -3.764122f, 2.599970f, 1.754555f, -2.069407f, -2.360138f, -0.389933f, 2.082109f, -2.417330f, 0.227301f, 2.479428f, -3.393506f, -1.060037f, 1.858956f, 0.774015f, -2.689951f, -0.043929f, 1.478755f, 1.487255f, 0.574802f, 1.113770f, -3.910411f, 0.072109f, 3.632040f, -3.804136f, -0.769365f, -3.117898f, 1.943197f, 2.546530f, -1.472595f, 1.416041f, -1.017438f, 0.026873f, -2.370532f, -2.931154f, 1.176275f, 1.125029f, -0.037746f, -1.624181f, 2.677275f, -1.247378f, 0.982527f, 0.765661f, 1.067716f, -0.796064f, 2.108122f, -2.401323f, -1.557218f, 0.454245f, -1.243593f, -0.936531f, 4.374903f, -0.364591f, -1.094196f, -7.075156f, -2.246040f, 3.494439f, 0.436160f, 0.639632f, -5.723710f, -3.902966f, 4.918394f, -13.775630f, 0.392317f, 5.014921f, -2.976084f, 2.448098f, 0.500692f, 4.077861f, 3.802242f, -1.053386f, 0.144686f, 1.103474f, -0.763048f, 2.762721f, -2.049108f, 0.976298f, 1.025980f, 1.842975f, -1.154346f, 1.787043f, 4.130215f, 0.234552f, 2.139116f, 1.832744f, -5.218890f, 0.690369f, -2.479496f, 12.980020f, 8.543007f, 5.422569f, -0.336791f, 0.326809f, 1.244663f, -2.494606f, -2.768842f, 2.136100f, -0.212743f, -1.101083f, 3.548764f, -2.378284f, 0.350117f, 0.016333f, 0.913844f, 0.824329f, -3.497905f, 2.191401f, -4.795359f, -0.539614f, -2.904305f, 0.460879f, 4.634485f, 3.591356f, 0.915933f, 1.716770f, 1.001406f, 1.497516f, -0.397141f, -0.280150f, -1.034232f, 0.719385f, -3.590359f, 1.384336f, -0.874948f, 2.746494f, -0.747896f, 1.903057f, 2.317667f, -0.246110f, -1.783799f, 1.383249f, -2.535010f, 0.468420f, 4.030691f, 1.346799f, -3.719729f, -0.032393f, 0.439832f, 1.463356f, -1.584387f, -1.716161f, -0.630991f, 4.391867f, -2.066006f, 3.772036f, -0.508105f, 1.538830f, 1.468175f, 0.440685f, 0.975221f, 6.606549f, -3.061610f, 0.345716f, -0.335859f, 2.261206f, -2.772151f, 1.449299f, -3.170364f, -17.450460f, 3.825989f, 1.332477f, -2.002182f, -1.922245f, 3.202103f, 3.481432f, -0.191602f, -3.947036f, 0.726389f, -2.206122f, 0.904964f, -0.833284f, -1.602697f, -0.282039f, 0.528151f, 3.618672f, -4.292654f, 2.546718f, -0.041807f, 2.880211f, 3.476939f, 12.447280f, -1.624929f, 2.355211f, 0.149431f, 2.026758f, -2.226142f, 8.271362f, 0.896730f, -0.064297f, -0.736653f, 5.932241f, -5.074384f, -0.642113f, -2.967956f, -1.219227f, 1.134366f, 1.756210f, -2.178246f, -1.099072f, 2.543672f, -8.565373f, 0.534164f, 7.167204f, 3.602790f, -1.361388f, -0.783606f, -3.463984f, 3.505873f, 0.030670f, 0.973877f, -1.900697f, -0.599029f, -0.063818f, 3.150252f, -1.909906f, -3.974473f, 3.276208f, -1.586323f, -0.404381f, -4.275898f, 2.943381f, -0.331879f, 2.622896f,],
        ["Some $tr!ng with unusual characters ( ͡❛ ʖ ͡❛) 😜"] = [-10.217220f, -2.690707f, 5.532714f, -2.755321f, -3.458218f, -1.542435f, 4.357506f, 0.603858f, 3.626412f, -0.978189f, 0.998810f, -3.137418f, 0.544885f, 3.225648f, 4.780656f, -2.656006f, 2.286538f, -0.373122f, -6.888706f, 2.058053f, 2.143417f, -3.074081f, 3.421689f, -3.390022f, 4.696154f, 0.934240f, -5.368046f, -2.121675f, 5.774008f, -14.476820f, 0.957073f, 3.360174f, -0.748551f, -0.957271f, 3.362706f, -0.743817f, -7.170151f, 1.600528f, 2.292704f, 0.682703f, 0.191456f, 2.478491f, -4.690265f, -2.466542f, 1.297324f, -7.455334f, -6.373093f, 1.348299f, -2.609322f, 1.297286f, -3.963282f, -1.229850f, 0.747615f, 4.490580f, 4.549756f, 3.864107f, 6.190032f, 3.978628f, 1.451332f, 1.729440f, 6.323083f, 3.173749f, -10.265480f, 5.075617f, -1.477465f, 2.477673f, 0.275532f, -2.082372f, 1.397810f, 9.041118f, 5.052019f, -0.700084f, -0.483344f, 8.241637f, 1.831739f, -0.713236f, -1.990013f, -1.470719f, -1.761394f, 0.329463f, 1.177490f, -1.043041f, -0.545912f, 3.404671f, -3.787619f, 0.725663f, 1.336927f, -1.913162f, -2.767050f, -1.087225f, 0.261788f, -5.251414f, 2.976318f, 4.438261f, -6.921422f, -0.086581f, 1.716236f, 1.677629f, -3.193703f, 14.861980f, -1.870214f, -2.414932f, 5.245515f, -5.407280f, 1.017061f, 1.740769f, -2.146165f, -4.907693f, -6.026373f, 0.539088f, -2.611388f, 1.923531f, 3.814631f, -7.954470f, -2.100599f, 3.679140f, 3.588650f, -1.147393f, 0.099812f, 2.230681f, 0.032705f, 2.883539f, -3.157897f, -3.292937f, -0.395949f, -2.591352f, 4.078865f, 7.959403f, 7.400565f, 8.591046f, 2.333144f, 5.879772f, 0.482084f, -1.912826f, -1.296336f, -4.739799f, -4.504830f, 3.226097f, -0.374272f, 1.701814f, -3.542193f, -3.806872f, -4.395949f, -9.064653f, -2.360760f, 2.408273f, -2.952176f, -2.836248f, 2.871510f, 0.525136f, 0.361426f, 4.624604f, -0.080850f, 0.719392f, 0.526742f, -0.293172f, 7.327601f, 11.350500f, -5.381397f, -2.439950f, 0.556627f, -5.837904f, -3.065855f, 2.766338f, 5.350682f, -10.813810f, -1.975480f, -2.586333f, 2.817876f, -5.031349f, -1.515838f, -0.070102f, -6.554358f, 1.744239f, 11.764680f, 0.559810f, 0.013377f, -2.387665f, -5.200356f, 0.575381f, 0.638956f, -2.500154f, -5.576529f, 2.981063f, 1.857091f, -4.533240f, -0.872087f, -0.983422f, 4.217736f, 1.201130f, 1.576923f, 0.235857f, -4.148648f, -4.006620f, -2.760602f, -5.295972f, -0.548150f, -2.076663f, 1.471033f, -3.908018f, 15.034650f, -4.607684f, -3.111508f, -3.931574f, 2.552330f, 1.028459f, 10.245480f, -1.799371f, -2.743708f, 6.723906f, -5.532347f, 5.281290f, 3.465978f, 4.715848f, 0.989432f, -1.923945f, -3.757646f, 5.652652f, 0.039088f, -0.258144f, -2.525057f, -8.444564f, -5.194603f, -26.679320f, 0.304082f, 5.239438f, -5.181273f, 3.735473f, -2.619916f, -3.025997f, 3.370282f, 8.489345f, 8.481838f, 3.146913f, -2.095547f, -1.052446f, -3.978319f, 1.305108f, 5.669970f, 3.045996f, -2.256213f, 6.374377f, 0.241172f, -2.601669f, 4.601023f, -5.152418f, -10.440830f, -0.833977f, 2.439642f, 15.439990f, 12.312150f, 1.086489f, -5.234793f, 6.351201f, 0.552792f, -0.851236f, -4.284349f, 5.626165f, 1.788437f, -4.603272f, 4.993357f, -2.137751f, -1.668925f, 3.857514f, 1.854311f, -2.944886f, -4.808938f, 1.175292f, -5.339955f, -4.746106f, -4.499632f, -0.155151f, 5.812567f, 3.945556f, 2.115035f, 3.292687f, 2.901607f, 0.502329f, -6.927125f, -3.123019f, 0.087074f, 1.884928f, 0.034135f, 1.360597f, -4.687669f, 6.235598f, -4.290006f, 0.591586f, -0.994145f, 1.312094f, -2.158764f, 3.681526f, 2.164449f, -4.183520f, 3.785921f, 1.218353f, 5.065754f, 5.992287f, -0.652894f, -1.343655f, -0.166362f, -3.008609f, 1.232511f, 0.596712f, -2.908026f, 3.830902f, 0.012543f, -1.750199f, 1.075544f, 1.503934f, -3.940536f, 9.515438f, -1.454098f, -1.378434f, -1.003614f, -1.424410f, -3.931155f, 3.663873f, -5.089249f, -30.525510f, 3.152409f, -0.120515f, -0.614628f, 1.766556f, 5.103483f, -0.621422f, -3.259213f, -5.511962f, 3.411652f, -0.106058f, 6.046061f, 1.901072f, -6.039001f, 1.897084f, -2.531032f, 6.262840f, -5.490563f, 2.522510f, -3.116087f, 0.760706f, -2.248241f, 27.671260f, 0.358011f, -2.042812f, -1.804536f, -0.668672f, 3.795393f, 6.724510f, -1.197951f, -0.629350f, 1.839335f, 7.594605f, -1.326965f, 3.262162f, 0.083339f, -4.987484f, 3.632098f, -2.514426f, 0.074454f, -7.774203f, 4.052383f, -8.390944f, 1.204956f, 8.406672f, -0.486295f, -4.346338f, 1.806496f, 2.026455f, 1.213485f, -0.892503f, 3.702022f, -5.764408f, 0.069156f, 4.507568f, 4.730269f, -3.581199f, -3.120154f, 4.959212f, -0.419242f, -3.912914f, 0.186799f, -1.949574f, 2.828259f, -2.584121f,],
        ["This is a pretty long string that should be tokenized into more than 512 tokens, which is the maximum supported by the model. Just to be sure, here's a lot more text: [Enter THESEUS, HIPPOLYTA, PHILOSTRATE, and Attendants]\n\nTheseus. Now, fair Hippolyta, our nuptial hour\nDraws on apace; four happy days bring in\nAnother moon: but, O, methinks, how slow\nThis old moon wanes! she lingers my desires,5\nLike to a step-dame or a dowager\nLong withering out a young man revenue.\nHippolyta. Four days will quickly steep themselves in night;\nFour nights will quickly dream away the time;\nAnd then the moon, like to a silver bow10\nNew-bent in heaven, shall behold the night\nOf our solemnities.\nTheseus. Go, Philostrate,\nStir up the Athenian youth to merriments;\nAwake the pert and nimble spirit of mirth;15\nTurn melancholy forth to funerals;\nThe pale companion is not for our pomp.\n[Exit PHILOSTRATE]\nHippolyta, I woo'd thee with my sword,\nAnd won thy love, doing thee injuries;20\nBut I will wed thee in another key,\nWith pomp, with triumph and with revelling.\n[Enter EGEUS, HERMIA, LYSANDER, and DEMETRIUS]\n\nEgeus. Happy be Theseus, our renowned duke!\nTheseus. Thanks, good Egeus: what's the news with thee?25\nEgeus. Full of vexation come I, with complaint\nAgainst my child, my daughter Hermia.\nStand forth, Demetrius. My noble lord,\nThis man hath my consent to marry her.\nStand forth, Lysander: and my gracious duke,30\nThis man hath bewitch'd the bosom of my child;\nThou, thou, Lysander, thou hast given her rhymes,\nAnd interchanged love-tokens with my child:\nThou hast by moonlight at her window sung,\nWith feigning voice verses of feigning love,35\nAnd stolen the impression of her fantasy\nWith bracelets of thy hair, rings, gawds, conceits,\nKnacks, trifles, nosegays, sweetmeats, messengers\nOf strong prevailment in unharden'd youth:\nWith cunning hast thou filch'd my daughter's heart,40\nTurn'd her obedience, which is due to me,\nTo stubborn harshness: and, my gracious duke,\nBe it so she; will not here before your grace\nConsent to marry with Demetrius,\nI beg the ancient privilege of Athens,45\nAs she is mine, I may dispose of her:\nWhich shall be either to this gentleman\nOr to her death, according to our law\nImmediately provided in that case.\nTheseus. What say you, Hermia? be advised fair maid:50\nTo you your father should be as a god;\nOne that composed your beauties, yea, and one\nTo whom you are but as a form in wax\nBy him imprinted and within his power\nTo leave the figure or disfigure it.55\nDemetrius is a worthy gentleman.\nHermia. So is Lysander.\nTheseus. In himself he is;\nBut in this kind, wanting your father's voice,\nThe other must be held the worthier.60\nHermia. I would my father look'd but with my eyes.\nTheseus. Rather your eyes must with his judgment look.\nHermia. I do entreat your grace to pardon me.\nI know not by what power I am made bold,\nNor how it may concern my modesty,65\nIn such a presence here to plead my thoughts;\nBut I beseech your grace that I may know\nThe worst that may befall me in this case,\nIf I refuse to wed Demetrius.\nTheseus. Either to die the death or to abjure70\nFor ever the society of men.\nTherefore, fair Hermia, question your desires;\nKnow of your youth, examine well your blood,\nWhether, if you yield not to your father's choice,\nYou can endure the livery of a nun,75\nFor aye to be in shady cloister mew'd,\nTo live a barren sister all your life,\nChanting faint hymns to the cold fruitless moon.\nThrice-blessed they that master so their blood,\nTo undergo such maiden pilgrimage;80\nBut earthlier happy is the rose distill'd,\nThan that which withering on the virgin thorn\nGrows, lives and dies in single blessedness.\nHermia. So will I grow, so live, so die, my lord,\nEre I will my virgin patent up85\nUnto his lordship, whose unwished yoke\nMy soul consents not to give sovereignty.\nTheseus. Take time to pause; and, by the nest new moon—\nThe sealing-day betwixt my love and me,\nFor everlasting bond of fellowship—90\nUpon that day either prepare to die\nFor disobedience to your father's will,\nOr else to wed Demetrius, as he would;\nOr on Diana's altar to protest\nFor aye austerity and single life.95\nDemetrius. Relent, sweet Hermia: and, Lysander, yield."] = [-203.200900f, 53.424920f, 40.102700f, -57.898390f, -203.219500f, -62.441460f, -64.418600f, 18.798380f, 59.380840f, -51.468420f, -70.935420f, -146.832700f, -71.873210f, -3.048384f, 31.797210f, -42.942030f, 90.871800f, 147.041700f, -308.377100f, 91.160930f, 268.814900f, -122.168100f, 94.600010f, -162.977300f, 82.488570f, 132.013900f, -37.603180f, -135.654600f, -77.575770f, -463.576000f, 37.390790f, -39.155990f, 38.868230f, -15.057020f, -66.099650f, 26.291560f, -96.043050f, -57.576430f, -39.220800f, 114.961100f, 82.113140f, -20.525510f, -26.367810f, -110.700000f, -64.213840f, -129.261800f, -155.158400f, 6.125598f, -29.414170f, 68.849960f, -115.419900f, 27.487270f, -23.401470f, 99.537730f, 53.117030f, 21.507060f, 123.845600f, 136.255800f, 47.349110f, 74.115550f, 108.908100f, 82.566940f, -365.182300f, 233.875200f, -71.783260f, 25.904520f, -148.982800f, 28.358560f, 42.777440f, 224.618200f, 43.339780f, 153.369600f, 30.358090f, 191.369200f, 2.615047f, 68.695210f, 77.225210f, -174.203900f, -82.703590f, 6.234204f, 4.383430f, 56.613820f, 21.568190f, -58.744280f, -70.092060f, -30.230730f, 35.120330f, 14.063230f, 22.949320f, 94.049330f, -50.701050f, -68.592360f, -62.588290f, 66.401080f, -51.705800f, 40.454460f, 28.029100f, 120.353600f, -82.487960f, 164.541700f, 18.509530f, 110.761600f, 78.706890f, -66.821730f, 9.801002f, 1.983647f, 18.159680f, -97.336710f, -16.228370f, 17.960830f, 79.590670f, -43.347210f, 19.359140f, -156.508300f, 61.279160f, 25.994480f, 249.961200f, 1.260268f, 14.235630f, 62.179740f, -70.780840f, 26.673160f, 68.659310f, 47.841340f, 72.683550f, -123.325700f, 70.749340f, 149.297500f, -2.967795f, 169.453300f, 134.589500f, 0.922964f, -109.535400f, -89.527170f, -51.177840f, 24.519080f, 26.432640f, -151.241500f, 25.212390f, -96.854900f, -114.689900f, -335.553600f, -5.868317f, -227.690700f, 7.162708f, 90.270430f, 179.237100f, -24.079950f, -128.137300f, 23.768600f, -93.203370f, 16.460960f, 11.500300f, -123.965100f, 118.866400f, 7.029799f, 170.517300f, 341.005600f, -167.716000f, 7.953439f, 178.236700f, 21.407090f, -74.735990f, 80.169870f, 41.125130f, -61.769960f, 1.286686f, -27.425450f, -26.248280f, -77.277210f, 50.619600f, 57.203860f, -208.188100f, 161.395600f, 179.416700f, 24.746470f, -137.679300f, -103.054700f, 65.819590f, 149.857800f, -20.745900f, -141.640200f, -88.766100f, 56.273690f, 35.716660f, -96.756360f, 8.464821f, -26.121880f, 56.604520f, -62.296570f, -39.273300f, 50.558320f, -127.437600f, 34.797010f, -110.476100f, -176.422000f, -86.356430f, 11.443950f, -26.304680f, 40.360660f, -98.360190f, -116.970100f, -9.332995f, 108.156600f, 171.901200f, -48.311020f, 30.964400f, -99.536280f, 125.604400f, 21.995720f, 20.702340f, 82.698540f, 277.456900f, -39.079120f, -27.925910f, 131.346000f, 45.913610f, 34.983120f, -20.567110f, 66.919560f, 57.237410f, -159.007300f, -138.535300f, -478.702900f, -5.554827f, 2.765842f, -80.957210f, 253.487500f, -67.333830f, 52.378580f, -42.424500f, 100.292200f, 37.619660f, 74.805990f, -102.305700f, -154.901000f, -48.235070f, 24.252160f, 112.043400f, -155.814300f, 66.176540f, 106.131400f, 27.949000f, -7.924426f, 110.547600f, 98.457880f, -184.256400f, -131.170700f, -32.980510f, 415.930000f, 300.840000f, 33.326330f, -150.702200f, 129.732600f, 43.253420f, -40.839290f, -262.060500f, 185.055700f, 79.872640f, 41.937070f, 162.620000f, 24.863320f, -70.670390f, -170.201400f, 250.973200f, -101.677900f, -238.851000f, -123.183900f, -5.184658f, 18.442600f, -57.466010f, 193.290200f, 28.566950f, 35.036510f, -106.044900f, -62.357920f, 71.718510f, 85.206730f, -197.849900f, -220.292100f, -2.033226f, -44.245660f, 125.120800f, -27.814640f, -30.109410f, 37.065380f, -55.042100f, 77.421940f, -9.570646f, 21.390770f, 11.726390f, 92.015590f, -138.855000f, 33.041290f, 74.094050f, -195.550500f, -159.251800f, 181.980300f, 15.570220f, 96.523420f, 81.066270f, -137.192400f, 100.793000f, 34.971410f, -151.380800f, 93.928280f, 92.567080f, -82.428700f, 72.827200f, 21.417170f, 85.212210f, 100.962700f, -116.684600f, 24.829710f, 128.538900f, -64.897440f, 55.674720f, 54.767160f, -88.960100f, -725.700700f, 95.047390f, 52.736460f, -21.742180f, 31.772110f, 129.071700f, 102.715600f, 20.679970f, -107.260100f, 66.228890f, 12.718290f, 141.689600f, 53.449100f, -24.717770f, 85.959810f, 136.118100f, 3.284292f, -91.927190f, -100.182700f, -74.412030f, 12.119650f, 12.398450f, 359.742100f, -5.147210f, 11.436840f, 3.328679f, 26.985860f, 171.738400f, 186.331800f, -31.619080f, -72.967750f, 70.819330f, 191.200100f, -60.733670f, 95.489670f, 74.777650f, -77.590030f, -16.149240f, 22.956340f, 6.866036f, -8.212122f, 96.801050f, 7.458982f, -11.988280f, 260.096100f, 23.113400f, -60.756380f, -16.914920f, -38.553650f, 65.667030f, -38.425070f, -6.228164f, -183.341800f, 36.846050f, -35.485900f, 116.670200f, -11.581910f, -128.592500f, -42.980850f, -154.231100f, -130.465700f, -66.937290f, -37.472760f, 111.258700f, -113.553100f,],
    };
}
